/*
MIT License

Copyright (c) 2019 takubokudori

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PowerComposer
{
    public class GenerateException : Exception
    {
        public GenerateException(string msg) : base(msg)
        {
        }
    }

    public class RequestGenerator
    {
        private int _arrayIter; // Dictionary Iterator
        private string[] _arr;
        private bool _hasNext; //hasNext
        private Dictionary<string, string[]> _dict;
        private Dictionary<string, List<string>> _enumDict;
        public bool ErrorByUndefinedVar = false;

        public RequestGenerator()
        {
        }

        public RequestGenerator(string[] s)
        {
            ParseRequest(s);
            dict = null;
        }

        public RequestGenerator(string[] s, Dictionary<string, string[]> dict)
        {
            ParseRequest(s);
            this.dict = dict;
        }

        public RequestGenerator(Dictionary<string, string[]> dict)
        {
            this.dict = dict;
        }

        public Dictionary<string, string[]> dict
        {
            get => _dict;
            set => _dict = value ?? new Dictionary<string, string[]>();
        }

        public void ParseRequest(string[] arr)
        {
            // Get the number of Placeholders
            _arr = new string[arr.Length];
            Array.Copy(arr, _arr, arr.Length);
            InitIterator();
        }

        public void InitIterator()
        {
            _arrayIter = 0;
            _enumDict = new Dictionary<string, List<string>>();
            _hasNext = true;
        }

        // Generate hasNext
        public bool HasNext()
        {
            return _hasNext;
        }

        private void Iterate()
        {
            _arrayIter++;
        }

        // TODO: below
        // 1-9 1-99 00-12 a-zzA-Z0-99
        // #{0-2}{a-c} OR #{0-2&a-c} 0a 1b 2c
        // #{0-2|a-c} -> 0a 0b 0c 1a 1b 1c 2a 2b 2c
        // !{C:\test\test.txt} -> the contents of test.txt
        private string GenerateString(string plaintext)
        {
            if (_dict == null) throw new GenerateException("Uninitialized Dictionary");
            _hasNext = false;
            string ret = Regex.Replace(plaintext, "(#|\\$)\\{.*?\\}", m =>
            {
                string str = "";
                if (m.Value[0] == '$') // variable
                {
                    string varName = m.Value.Substring(2, m.Value.Length - 3); // ${abc} -> abc
                    if (_dict.ContainsKey(varName))
                    {
                        if (_dict[varName].Length > _arrayIter) str = _dict[varName][_arrayIter];
                        if (_arrayIter + 1 < _dict[varName].Length) _hasNext = true;
                    }
                    else if (ErrorByUndefinedVar)
                    {
                        _hasNext = false;
                        throw new GenerateException($"Undefined variable {varName}");
                    }
                }
                else if (m.Value[0] == '#') // enum
                {
                    string enumString = m.Value.Substring(2, m.Value.Length - 3); // #{1-9} -> 1-9
                    if (!_enumDict.ContainsKey(enumString)) _enumDict[enumString] = GenerateEnumArray(enumString);
                    if (_enumDict[enumString].Count > _arrayIter) str = _enumDict[enumString][_arrayIter];
                    if (_arrayIter + 1 < _enumDict[enumString].Count) _hasNext = true;
                }
                else if (m.Value[0] == '!') // include
                {
                    string filePath = m.Value.Substring(2, m.Value.Length - 3); // #{C:\test.txt} -> C:\test.txt
                    if (File.Exists(filePath))
                    {
                        str = File.OpenText(filePath).ReadToEnd();
                    }
                    else
                    {
                        _hasNext = false;
                        throw new GenerateException($"File: {filePath} is not exists");
                    }
                }

                return str;
            }, RegexOptions.CultureInvariant);


            return ret;
        }

        /*
         * digit=(0-9)+
         * alpha=(a-z)+
         * ALPHA=(A-Z)+
         * minus=-
         * or=|
         * and=&
         * token=(digit minus digit)|(alpha minus alpha)|(ALPHA minus ALPHA)
         * expr=token | expr token | (expr or expr) | (expr and expr)
         */
        public List<string> GenerateEnumArray(string enumString)
        {
            // 1-9a-z
            var ret = new List<string>();
            var vm = Regex.Matches(enumString, "([0-9]+-[0-9]+)|([a-z]+-[a-z]+)|([A-Z]+-[A-Z]+)",
                RegexOptions.CultureInvariant);
            foreach (Match m in vm)
            {
                string[] s = m.Value.Split('-');
                if (char.IsDigit(m.Value[0])) // 0-9
                {
                    int start = Convert.ToInt32(s[0]);
                    int end = Convert.ToInt32(s[1]);
                    if (start <= end) // 0-9
                    {
                        for (int i = start; i <= end; i++) ret.Add(i.ToString());
                    }
                    else // 9-0
                    {
                        for (int i = start; i >= end; i--) ret.Add(i.ToString());
                    }
                }
                else if (char.IsUpper(m.Value[0])) // A-Z
                {
                    char[] start = s[0].ToCharArray();
                    char[] end = s[1].ToCharArray();
                }
                else if (char.IsLower(m.Value[0])) // a-z
                {
                    char[] start = s[0].ToCharArray();
                    char[] end = s[1].ToCharArray();
                }
                else
                {
                    throw new GenerateException("Suspicious #Literal");
                }
            }

            return ret;
        }

        public string NextString(ref char[] s)
        {
            bool isUpper = char.IsUpper(s[0]);
            bool carry = true;
            if (isUpper)
            {
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (carry)
                    {
                        s[i]++;
                        carry = false;
                    }
                    else break;

                    if (s[i] > 'Z')
                    {
                        carry = true;
                        s[i] = 'A';
                    }

                    s[i]++;
                }
            }
            else
            {
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (carry)
                    {
                        s[i]++;
                        carry = false;
                    }
                    else break;

                    if (s[i] > 'z')
                    {
                        carry = true;
                        s[i] = 'a';
                    }

                    s[i]++;
                }
            }

            return carry ? 'A' + Convert.ToString(s) : Convert.ToString(s);
        }

        public string[] Generate()
        {
            string[] ret = new string[_arr.Length];
            _hasNext = false;
            for (int i = 0; i < _arr.Length; i++)
            {
                bool aa = _hasNext;
                ret[i] = GenerateString(_arr[i]);
                _hasNext |= aa;
            }

            Iterate();

            return ret;
        }
    }
}
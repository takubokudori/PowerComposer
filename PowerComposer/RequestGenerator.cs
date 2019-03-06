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

        private string GenerateString(string plaintext)
        {
            if (_dict == null) throw new GenerateException("Uninitialized Dictionary");
            _hasNext = false;
            string ret = Regex.Replace(plaintext, "\\$\\{.*?\\}", m =>
            {
                string varName = m.Value.Substring(2, m.Value.Length - 3);
                string str = "";
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

                return str;
            }, RegexOptions.CultureInvariant);


            return ret;
        }

        /*
        public string GenerateStringTest(string plaintext)
        {
            if (_dict == null) throw new GenerateException("Uninitialized Dictionary");

            int ps; // ${ , } position
            string ret = ""; // return string
            int reqPtr = 0;
            _hasNext = false;
            while ((ps = plaintext.IndexOf("${", reqPtr, StringComparison.Ordinal)) != -1)
            {
                int pe = plaintext.IndexOf("}", reqPtr, StringComparison.Ordinal); // }
                if (pe == -1) // ${...<EOS>
                {
                    _hasNext = false;
                    throw new GenerateException("Broken brackets found");
                }

                string varName = plaintext.Substring(ps + 2, pe - (ps + 2)); // ${varName}
                string str = "";
                if (_dict.ContainsKey(varName))
                {
                    if (_arrayIter < _dict[varName].Length)
                    {
                        str = _dict[varName][_arrayIter];
                        if (_arrayIter + 1 < _dict[varName].Length) _hasNext = true;
                    }
                }
                else
                {
                    if (ErrorByUndefinedVar)
                    {
                        _hasNext = false;
                        throw new GenerateException($"Undefined variable {varName}");
                    }
                }

                ret += $@"{plaintext.Substring(reqPtr, ps - reqPtr)}{str}";

                reqPtr = pe + 1;
            }

            ret += plaintext.Substring(reqPtr);

            return ret;
        }
        */

        public string[] Generate()
        {
            string[] ret = new string[_arr.Length];
            _hasNext = false;
            for (int i = 0; i < _arr.Length; i++)
            {
                bool aa = _hasNext;
                ret[i] = GenerateString(_arr[i]);
                _hasNext = _hasNext || aa;
            }

            Iterate();

            return ret;
        }
    }
}
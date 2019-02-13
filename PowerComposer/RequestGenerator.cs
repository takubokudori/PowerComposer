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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PowerComposer
{
    public class RequestGenerator
    {
        private int _arrayIter; // Dictionary Iterator
        private string _request;
        private bool _hasNext; //hasNext
        private Dictionary<string, string[]> _dict;
        public bool _errorByUndefinedVar = false;

        public RequestGenerator()
        {
        }

        public RequestGenerator(string s)
        {
            ParseRequest(s);
            SetDict(null);
        }

        public RequestGenerator(string s, Dictionary<string, string[]> dict)
        {
            ParseRequest(s);
            SetDict(dict);
        }

        public RequestGenerator(Dictionary<string, string[]> dict)
        {
            SetDict(dict);
        }

        public void SetDict(Dictionary<string, string[]> dict)
        {
            this._dict = dict ?? new Dictionary<string, string[]>();
        }

        public void ParseRequest(string s)
        {
            // Get the number of Placeholders
            _request = s;
            int num = GetTheNumberOfPlaceholders();
            InitIterator();
        }

        private int GetTheNumberOfPlaceholders()
        {
            int num = 0;
            int ds, de = -1;
            while ((ds = _request.IndexOf("${", de + 1, StringComparison.Ordinal)) != -1)
            {
                de = _request.IndexOf("}", ds + 2, StringComparison.Ordinal);
                if (de == -1) break;
                num++;
            }

            return num;
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

        private void iterate()
        {
            _arrayIter++;
        }

        private string GenerateString(string plaintext)
        {
            if (plaintext == null)
            {
                MessageBox.Show(@"UnInitialized RequestGenerator!");
                return "";
            }

            int ps; // ${ , } position
            string ret = ""; // return string
            int reqPtr = 0;
            _hasNext = false;
            while ((ps = plaintext.IndexOf("${", reqPtr, StringComparison.Ordinal)) != -1)
            {
                int pe = plaintext.IndexOf("}", reqPtr, StringComparison.Ordinal); // }
                if (pe == -1) // ${...<EOS>
                {
                    MessageBox.Show(@"Broken Brackets found!");
                    _hasNext = false;
                    return "";
                }

                string varName = plaintext.Substring(ps + 2, pe - (ps + 2)); // ${varName}
                string str = "";
                if (_dict.ContainsKey(varName))
                {
                    if (_arrayIter < _dict[varName].Length)
                    {
                        str = _dict[varName][_arrayIter];
                        _hasNext = true;
                    }
                }
                else
                {
                    if (_errorByUndefinedVar)
                    {
                        MessageBox.Show($@"Undefined variable {varName}.");
                        _hasNext = false;
                        return "";
                    }
                }

                ret += plaintext.Substring(reqPtr, ps - reqPtr) + str;

                reqPtr = pe + 1;
            }

            ret += plaintext.Substring(reqPtr);
            _arrayIter++;

            return ret;
        }

        public string[] Generate()
        {
            string[] _arr = new string[4];
            string[] ret = new string[4];
            for (int i = 0; i < _arr.Length; i++)
            {
                bool aa = _hasNext;
                ret[i] = GenerateString(_arr[i]);
                _hasNext = _hasNext || aa;
            }

            return ret;
        }

        public string Generate(bool errorByUndefinedVar = false)
        {
            if (_request == null)
            {
                MessageBox.Show(@"UnInitialized RequestGenerator!");
                return "";
            }

            int ps; // ${ , } position
            string ret = ""; // return string
            int reqPtr = 0;
            _hasNext = false;
            while ((ps = _request.IndexOf("${", reqPtr, StringComparison.Ordinal)) != -1)
            {
                int pe = _request.IndexOf("}", reqPtr, StringComparison.Ordinal); // }
                if (pe == -1) // ${...<EOS>
                {
                    MessageBox.Show(@"Broken Brackets found!");
                    _hasNext = false;
                    return "";
                }

                string varName = _request.Substring(ps + 2, pe - (ps + 2)); // ${varName}
                string str = "";
                if (_dict.ContainsKey(varName))
                {
                    if (_arrayIter < _dict[varName].Length)
                    {
                        str = _dict[varName][_arrayIter];
                        _hasNext = true;
                    }
                }
                else
                {
                    if (errorByUndefinedVar)
                    {
                        MessageBox.Show($@"Undefined variable {varName}.");
                        _hasNext = false;
                        return "";
                    }
                }

                ret += _request.Substring(reqPtr, ps - reqPtr) + str;

                reqPtr = pe + 1;
            }

            ret += _request.Substring(reqPtr);
            _arrayIter++;

            return ret;
        }
    }
}
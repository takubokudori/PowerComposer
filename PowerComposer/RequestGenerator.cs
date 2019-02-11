using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PowerComposer
{
    public class RequestGenerator
    {
        private int _placeholderNum;
        private int[] _arrayIter;
        private string _request;
        private bool _hasNext; //hasNext
        private Dictionary<string, string[]> _dict;

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
            _placeholderNum = num;
            _arrayIter = new int[_placeholderNum];
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
            if (_arrayIter == null) return;
            for (int i = 0; i < _arrayIter.Length; i++)
            {
                _arrayIter[i] = 0;
            }

            _hasNext = true;
        }

        // Generate hasNext
        public bool HasNext()
        {
            return _hasNext;
        }

        public string Generate()
        {
            if (_request == null)
            {
                MessageBox.Show(@"UnInitialized RequestGenerator!");
                return "";
            }

            int ps; // ${ , } position
            string ret = ""; // return string
            int nowPh = 0; // now placeholder
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
                    if (_arrayIter[nowPh] < _dict[varName].Length)
                    {
                        str = _dict[varName][_arrayIter[nowPh]];
                        _arrayIter[nowPh]++;
                        _hasNext = true;
                    }
                }
                else
                {
                    MessageBox.Show($@"Undefined variable {varName}.");
                    _hasNext = false;
                    return "";
                }

//                MessageBox.Show(request.Substring(reqPtr, ps - reqPtr + 1));
//                MessageBox.Show(str);
                ret += _request.Substring(reqPtr, ps - reqPtr) + str;

                reqPtr = pe + 1;

                nowPh++;
            }

            ret += _request.Substring(reqPtr);

            return ret;
        }
    }
}
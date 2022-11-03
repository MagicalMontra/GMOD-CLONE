using System;
using System.Collections;

namespace Gamespace.Localization
{
    public class LongParseTree
    {
        private Trie _dict;

        private ArrayList _indexList;
        private ArrayList _typeList;
        private ArrayList _frontDepChar;
        private ArrayList _rearDepChar;
        private ArrayList _tonalChar;
        private ArrayList _endingChar;

        public void Initialize(Trie dict, ArrayList indexList, ArrayList typeList)
        {
            _dict = dict;
            _indexList = indexList;
            _typeList = typeList;
            _frontDepChar = new ArrayList();
            _rearDepChar = new ArrayList();
            _tonalChar = new ArrayList();
            _endingChar = new ArrayList();
            
            _frontDepChar.AddRange(new[] { "ะ", "ั", "า", "ำ", "ิ", "ี", "ึ", "ื", "ุ", "ู", "ๅ", "็", "์", "ํ" });
            _rearDepChar.AddRange(new[] { "ั", "ื", "เ", "แ", "โ", "ใ", "ไ", "ํ" });
            _tonalChar.AddRange(new[] { "่", "้", "๊", "๋" });
            _endingChar.AddRange(new[] { "ๆ", "ฯ" });
        }
        private Boolean NextWordValid(int beginPos, String text)
        {
            int pos = beginPos + 1;
            int status;
            if (beginPos == text.Length)
                return true;
            
            if (text[beginPos] <= '~')
                return true;
            
            while (pos <= text.Length)
            {
                status = _dict.Contains(text.Substring(beginPos, (pos - beginPos)));
                if (status == 1)
                    return true;
                
                if (status == 0)
                    pos++;
                else
                    break;

            }
            
            return false;
        }
        public int ParseWordInstance(int beginPos, String text)
        {
            char prevChar = Convert.ToChar(0);
            int longestPos = -1;
            int longestValidPos = -1;
            int numValidPos = 0;
            int returnPos = -1;
            int pos, status;

            status = 1;
            numValidPos = 0;
            pos = beginPos + 1;
            while ((pos <= text.Length) && (status != -1))
            {
                status = _dict.Contains(text.Substring(beginPos, (pos - beginPos)));
                //Record longest so far
                if (status == 1)
                {
                    longestPos = pos;
                    if (NextWordValid(pos, text))
                    {
                        longestValidPos = pos;
                        numValidPos++;
                    }
                }
                pos++;
            }
            
            if (beginPos >= 1)
            {
                prevChar = text[beginPos - 1];
            }

            //Unknow word
            if (longestPos == -1)
            {
                returnPos = beginPos + 1;

                var unknown1 = _frontDepChar.Contains("" + text[beginPos]);
                var unknown2 = (_tonalChar.Contains("" + text[beginPos]));
                var unknown3 = (_rearDepChar.Contains("" + prevChar));
                var unknown4 = _typeList.Count > 0 && (((short)_typeList[_typeList.Count - 1] == 0));
                if ((_indexList.Count > 0) && (unknown1 || unknown2 || unknown3 || unknown4))
                {

                    _indexList[_indexList.Count - 1] = (short)returnPos;
                    _typeList[_typeList.Count - 1] = (short)0;
                }
                else
                {
                    _indexList.Add((short)returnPos);
                    _typeList.Add((short)0);
                }
                return returnPos;
            }
            if (longestValidPos == -1)
            {
                if (_rearDepChar.Contains("" + prevChar))
                {
                    _indexList[_indexList.Count - 1] = (short)longestPos;
                    _typeList[_typeList.Count - 1] = (short)0;
                }
                else
                {
                    _typeList.Add((short)1);
                    _indexList.Add((short)longestPos);
                }
                return longestPos;
            }
            
            if (_rearDepChar.Contains("" + prevChar))
            {
                _indexList[_indexList.Count - 1] = (short)longestValidPos;
                _typeList[_typeList.Count - 1] = (short)0;
            }
            else if (numValidPos == 1)
            {
                _typeList.Add((short)1);
                _indexList.Add((short)longestValidPos);
            }
            else
            {
                _typeList.Add((short)2);
                _indexList.Add((short)longestValidPos);
            }
            return (longestValidPos);
        }
    }
}
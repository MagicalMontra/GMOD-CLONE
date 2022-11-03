using System;
using System.Collections.Generic;
using Zenject;

namespace Gamespace.Localization
{
    public class HtmlTagParser : ITagParser
    {
        [Inject] private TagStringParser _tagStringParser;
        private readonly Char SPECIAL_TAG = '\uFFF0';
        public string ParserTag(string value, out List<string> tagList)
        {
            TagString[] tagArr = _tagStringParser.Parser(value);
            string parserValue = "";
            tagList = new List<string>();
            foreach (TagString tag in tagArr)
            {
                if (tag.IsTag)
                {
                    parserValue += SPECIAL_TAG;
                    tagList.Add(tag.GetTagString());
                }
                else
                {
                    parserValue += tag.GetTagString();
                }
            }
            return parserValue;
        }
    }
}
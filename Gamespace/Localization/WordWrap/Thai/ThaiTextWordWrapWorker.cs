using System;
using Zenject;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Localization
{
    public class ThaiTextWordWrapWorker : IWordWrapWorker
    {
        private readonly Char SEPARATOR = '\u200B';
        private readonly Char NEWLINE = '\u000A';
        private readonly Char SPACE = '\u0020';
        private readonly Char SPECIAL_TAG = '\uFFF0';
        private readonly Char APPEND_NEWLINE = '\n';
        
        [Inject] private ITagParser _tagParser;
        
        private ITokenizer _tokenizer;

        public void Initialize(ITokenizer tokenizer)
        {
            _tokenizer = tokenizer;
        }
        public string Wrap(string value, float boxWidth, Font font)
        {
            if (!ThaiFontAdjuster.IsThaiString(value))
                return value;
            
            value = value.Replace("\\n", "\n");
            List<string> htmlTag;
            string inputText = _tagParser.ParserTag(value, out htmlTag);
            inputText = _tokenizer.InsertLineBreaks(inputText, SEPARATOR);
            char[] arr = inputText.ToCharArray();
            CharacterInfo characterInfo = new CharacterInfo();
            
            if (font != null)
                font.RequestCharactersInTexture(inputText, font.fontSize);
            
            string outputText = "";
            int lineLength = 0;
            string word = "";
            int wordLength = 0;
            int SEPARATOR_Count = 0;
            foreach (char c in arr)
            {
                if (c == SEPARATOR)
                {
                    outputText = AddWordToText(inputText, lineLength, word, wordLength, boxWidth, out lineLength);
                    word = "";
                    wordLength = 0;
                    SEPARATOR_Count++;
                    continue;
                }
                
                if (c == NEWLINE)
                {
                    outputText = AddNewLineToText(inputText, lineLength, word, wordLength, boxWidth, out lineLength);
                    word = "";
                    wordLength = 0;
                    continue;
                }
                
                if (font != null && font.GetCharacterInfo(c, out characterInfo, font.fontSize))
                {
                    if (c == SPACE)
                    {
                        outputText = AddSpaceToText(inputText, lineLength, word, wordLength, characterInfo.advance, boxWidth, out lineLength);
                        word = "";
                        wordLength = 0;
                    }
                    else if (c == SPECIAL_TAG)
                    {
                        outputText = AddWordToText(inputText, lineLength, word, wordLength, boxWidth, out lineLength);
                        word = "";
                        wordLength = 0;
                        outputText += htmlTag[0];
                        htmlTag.RemoveAt(0);
                    }
                    else
                    {
                        word += c;
                        wordLength += characterInfo.advance;
                    }
                }
            }
            outputText = AddWordToText(inputText, lineLength, word, wordLength, boxWidth, out lineLength); // Add remaining word
            outputText = ThaiFontAdjuster.Adjust(outputText);
            return outputText;
        }

        private string AddSpaceToText(string inputText, int lineLength, string word, int wordLength, int spaceWidth, float boxWidth, out int totalLength)
        {
            string outputText;
            if (lineLength + wordLength + spaceWidth <= boxWidth)
            {
                outputText = inputText + word + SPACE;
                totalLength = lineLength + wordLength + spaceWidth;
            }
            else if (lineLength + wordLength <= boxWidth)
            {
                outputText = inputText + word + APPEND_NEWLINE;
                totalLength = 0;
            }
            else
            {
                outputText = inputText + APPEND_NEWLINE + word + SPACE;
                totalLength = wordLength + spaceWidth;
            }
            return outputText;
        }

        private string AddWordToText(string inputText, int lineLength, string word, int wordLength, float boxWidth, out int totalLength)
        {
            string outputText;
            if (lineLength + wordLength <= boxWidth)
            {
                outputText = inputText + word;
                totalLength = lineLength + wordLength;
            }
            else
            {
                outputText = inputText + APPEND_NEWLINE + word;
                totalLength = wordLength;
            }
            return outputText;
        }

        private string AddNewLineToText(string inputText, int lineLength, string word, int wordLength, float boxWidth, out int totalLength)
        {
            string outputText;
            if (lineLength + wordLength <= boxWidth)
            {
                outputText = inputText + word + APPEND_NEWLINE;
                totalLength = 0;
            }
            else
            {
                outputText = inputText + APPEND_NEWLINE + word;
                totalLength = wordLength;
            }
            return outputText;
        }
        
        public class Factory : PlaceholderFactory<string, IWordWrapWorker> {}
    }
}

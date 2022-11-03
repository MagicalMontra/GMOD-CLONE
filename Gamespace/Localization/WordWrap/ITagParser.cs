using System.Collections.Generic;

namespace Gamespace.Localization
{
    public interface ITagParser
    {
        string ParserTag(string value, out List<string> tagList);
    }
}
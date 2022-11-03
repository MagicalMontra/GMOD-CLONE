using System.Collections;
using System.IO;

namespace Gamespace.Localization
{
    public interface IDictionary
    {
        int first { get; }
        int next { get; }
        bool hasNext { get; }
        ArrayList lineList { get; }
        ArrayList typeList { get; }
        ArrayList indexList { get; }
        void Initialize(StreamReader input);
        void WordInstance(string text);
        void LineInstance(string text);
    }
}
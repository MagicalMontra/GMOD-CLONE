using UnityEngine;
using Zenject;

namespace Gamespace.UI.ProgressScreen
{
    public interface IProgressScreen
    {
        GameObject gameObject { get; }
        void Close(string text);
        void Show(int current, int total, string text);
        
        public class Factory : PlaceholderFactory<Object, IProgressScreen>{ }
    }
}
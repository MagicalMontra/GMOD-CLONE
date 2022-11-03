using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Gamespace.UI
{
    public interface IUIAnimation
    {
        float Duration { get; }
        UniTaskVoid On();
        UniTaskVoid Off();
        void Reset();
        void OnDestroy();
    }
}
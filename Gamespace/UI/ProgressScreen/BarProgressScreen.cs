using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.UI.ProgressScreen
{
    public class BarProgressScreen : MonoBehaviour, IProgressScreen
    {
        [SerializeField] private Slider _bar;
        [SerializeField] private TextMeshProUGUI _progressText;
        
        public void Close(string text)
        {
            _bar.value = 1f;
            _progressText.text = $"{text}";
        }
        public void Show(int current, int total, string text)
        {
            var progress = (float)current / (float)total;
            _bar.value = progress;
            _progressText.text = $"{text} {current}/{total}";
        }
    }
}
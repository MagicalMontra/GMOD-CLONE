using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamespace.Core.ObjectMode.Placing
{
    public class PlaceableObjectCategoryUI : MonoBehaviour
    {
        [SerializeField] private Sprite _normalSprite;
        [SerializeField] private Sprite _selectedSprite;
        [SerializeField] private TextMeshProUGUI _catText;
        [SerializeField] private List<Image> _images = new List<Image>();
        
        public void AddImageObject(Image image)
        {
            _images.Add(image);
        }
        public void SetPointerImage(int index)
        {
            for (int i = 0; i < _images.Count; i++)
            {
                if (i == index)
                {
                    _images[i].sprite = _selectedSprite;
                    continue;
                }

                _images[i].sprite = _normalSprite;
            }
        }
        public void SetText(string catName)
        {
            _catText.text = catName;
        }
    }
}
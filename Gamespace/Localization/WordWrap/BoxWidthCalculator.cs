using UnityEngine;

namespace Gamespace.Localization
{
    public class BoxWidthCalculator
    {
        public float GetBoxWidth(RectTransform rectTransform)
        {
            float boxwidth = rectTransform.rect.width;
            if (boxwidth <= 0)
            {
                Vector3[] corners = new Vector3[4];
                rectTransform.GetWorldCorners(corners);
                boxwidth = Vector3.Distance(corners[0], corners[3]);
            }
            return boxwidth;
        }
    }
}
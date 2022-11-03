using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutSceneBlackImage : MonoBehaviour
{
    private bool isFading;
    private bool isBlackImage;
    private bool isEnable;
    public Image[] cutSceneImages;
   
    public void ActiveBlackImages(bool isEnable_)
    {
        isEnable = isEnable_;
        for (int i = 0; i < cutSceneImages.Length; i++)
        {
            cutSceneImages[i].gameObject.SetActive(isEnable_);
        }
    }

    public void FadeBlackImage(bool isFade)
    {
        if (!isEnable)
            return;
        if (isFading)
            return;

        isFading = true;
        StartCoroutine(FadeImage(isFade));
    }
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            isBlackImage = false;

            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                for (int k = 0; k < cutSceneImages.Length; k++)
                {
                    cutSceneImages[k].color = new Color(0, 0, 0, i);
                }
                isFading = false;
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second

            if (isBlackImage)
            {
                isFading = false;
                yield return null;
            }
            else
            {
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    for (int k = 0; k < cutSceneImages.Length; k++)
                    {
                        cutSceneImages[k].color = new Color(0, 0, 0, i);
                    }
                    isFading = false;
                    yield return null;
                }
            }

            isBlackImage = true;

        }
    }
}

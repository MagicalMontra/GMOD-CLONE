using System;
using UnityEngine;

public static class RectTransformExtensions 
{
    public static void AnchorToCorners(this RectTransform transform)
     {
       if (transform == null)
         throw new ArgumentNullException("transform");
 
       if (transform.parent == null)
         return;
 
       var parent = transform.parent.GetComponent<RectTransform>();
 
       Vector2 newAnchorsMin = new Vector2(transform.anchorMin.x + transform.offsetMin.x / parent.rect.width,
                         transform.anchorMin.y + transform.offsetMin.y / parent.rect.height);
 
       Vector2 newAnchorsMax = new Vector2(transform.anchorMax.x + transform.offsetMax.x / parent.rect.width,
                         transform.anchorMax.y + transform.offsetMax.y / parent.rect.height);
 
       transform.anchorMin = newAnchorsMin;
       transform.anchorMax = newAnchorsMax;
       transform.offsetMin = transform.offsetMax = new Vector2(0, 0);
     }
 
     public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec)
     {
       trans.pivot = aVec;
       trans.anchorMin = aVec;
       trans.anchorMax = aVec;
     }
 
     public static Vector2 GetSize(this RectTransform trans)
     {
       return trans.rect.size;
     }
 
     public static float GetWidth(this RectTransform trans)
     {
       return trans.rect.width;
     }
 
     public static float GetHeight(this RectTransform trans)
     {
       return trans.rect.height;
     }
 
     public static void SetSize(this RectTransform trans, Vector2 newSize)
     {
       Vector2 oldSize = trans.rect.size;
       Vector2 deltaSize = newSize - oldSize;
       trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
       trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
     }
 
     public static void SetWidth(this RectTransform trans, float newSize)
     {
       SetSize(trans, new Vector2(newSize, trans.rect.size.y));
     }
 
     public static void SetHeight(this RectTransform trans, float newSize)
     {
       SetSize(trans, new Vector2(trans.rect.size.x, newSize));
     }
 
     public static void SetBottomLeftPosition(this RectTransform trans, Vector2 newPos)
     {
       trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
     }
 
     public static void SetTopLeftPosition(this RectTransform trans, Vector2 newPos)
     {
       trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
     }
 
     public static void SetBottomRightPosition(this RectTransform trans, Vector2 newPos)
     {
       trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
     }
 
     public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos)
     {
       trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
     }

      public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
}

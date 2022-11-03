using System;
using UnityEngine.EventSystems;

namespace Gamespace.UI
{
    public interface IExtendedUI : 
        IPointerDownHandler,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerUpHandler
    {
    }
}
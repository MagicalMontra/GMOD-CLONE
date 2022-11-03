using System;

namespace Gamespace.Core.ObjectMode
{
    [Serializable]
    public enum PlaceType
    {
        Floor = 0,
        Wall,
        Ceiling,
        Stackable,
        Floatable,
    }
}
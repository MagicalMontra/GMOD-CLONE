using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Gamespace.Core.Blueprint
{
    public class RoomConsumer : MonoBehaviour
    {
       public class Factory :PlaceholderFactory<Object, RoomConsumer>
       {

       }
    }

}

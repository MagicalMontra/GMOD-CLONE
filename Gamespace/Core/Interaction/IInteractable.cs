using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamespace.Core.Interaction
{
    public interface IInteractable
    {
        string id { get; }
        float distanceFromPlayer { get; set; }
        Vector3 position { get; }
        GameObject gameObject { get; }
        void Interact();
        void OnInitialize();
        void OnDispose();
        void SetActive(bool enabled);
    }

}


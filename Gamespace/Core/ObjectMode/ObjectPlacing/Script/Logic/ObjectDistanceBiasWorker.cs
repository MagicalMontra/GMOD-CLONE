using System.Collections.Generic;
using Gamespace.Core.ObjectMode.Placing;
using Gamespace.Core.Player;
using UnityEngine;
using Zenject;

namespace Gamespace.Core.ObjectMode
{
    public class ObjectDistanceBiasWorker
    {
        private EditorPlayer _editorPlayer;

        public void SetDistance(IPlaceableObject placeable)
        {
            if (_editorPlayer is null)
                return;

            placeable.distanceFromPlayer = Vector3.Distance(_editorPlayer.position, placeable.position);
        }
        public void OnEditorPlayerInitialized(EditorInitializedSignal signal)
        {
            _editorPlayer = signal.player;
        }
    }
}
using System.Collections.Generic;
using Gamespace.Core.Player;
using UnityEngine;

namespace Gamespace.Core.Interaction
{
    public class InteractableDistanceBiasWorker
    {
        private PlayModePlayer _player;

        public void SetDistance(List<IInteractable> interactables)
        {
            if (_player is null)
                return;

            for (int i = 0; i < interactables.Count; i++)
            {
                interactables[i].distanceFromPlayer = Vector3.Distance(_player.position, interactables[i].position);
            }
        }
        public void OnPlaymodePlayerInitialized(PlayerInitializedSignal signal)
        {
            _player = signal.player;
        }
    }

}

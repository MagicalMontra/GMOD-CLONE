using System;
using Gamespace.UI;
using UnityEngine;

namespace Gamespace.Core.Actions
{
    public interface IActionBehaviour
    {
        string id { get; }
        string objectName { get; }
        Vector3 position { get; }
        void Next();
        void Next(int value);
        void Next(float value);
        void Next(string value);
        void Perform();
        void Perform(int value);
        void Perform(float value);
        void Perform(string value);
        void OnInitialized(string objectId, string objectName);
        void AssignNextAction(ActionLinkRenderer renderer, IActionBehaviour behaviour);
        void CancelLinkAction(string id);
        CircleWheelAction GetWheelAction();
        Type[] GetAcceptingTypes();
        void LinkWith();
    }
}
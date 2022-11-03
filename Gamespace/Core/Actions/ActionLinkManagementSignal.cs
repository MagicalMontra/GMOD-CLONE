using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Gamespace.Core.Actions
{
    public class ActionLinkManagementSignal
    {
        public string id => _id;
        private string _id;
        public ActionLinkManagementSignal(string id)
        {
            _id = id;
        }
    }
}
using System.Collections.Generic;

namespace Gamespace.Core.Actions
{
    public class ActionPropertyRequestSignal
    {
        public string name => _name;
        public string[] fieldNames => _fieldNames;
        public ActionVariable[] variables => _variables;

        private string _name;
        private string[] _fieldNames;

        private ActionVariable[] _variables;

        public ActionPropertyRequestSignal(string name, string[] fieldNames, params ActionVariable[] variables)
        {
            _name = name;
            _fieldNames = fieldNames;
            _variables = variables;
        }
    }
}
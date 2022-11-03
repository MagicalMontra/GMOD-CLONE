using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

namespace Gamespace.Utilis
{
    public static class LogUtility
    {
        public static void Assert(bool condition, string objectName, Type objectType, string message)
        {
            var format =
                $"<color=red><b>Assert hit</b></color> on instance <b>{objectName}</b>\nType: <b>{objectType}</b>\nMessage: <b>{message}</b>\nTimestamp: {DateTime.Now:f}";
            
            Debug.Assert(!condition, format);
        }

        public static void LogVars(string name, object variable)
        {
            var s = "";
            
            s += $"<color=green><b>Variable name:</b></color> {name}\n";
            s += $"<color=yellow><b>Variable value:</b></color> {variable}\n";

            Debug.Log(s);
        }
    }
}
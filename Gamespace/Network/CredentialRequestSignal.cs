using UnityEngine;

namespace Gamespace.Network
{
    public delegate void CredentialCallback();
    public class CredentialRequestSignal
    {
        public CredentialCallback onAccessExpired;
        public CredentialCallback onRefreshExpired;
    }

    public static class CredentialExtensions
    {
        public static T OnAccessExpired<T>(this T t, CredentialCallback action) where T : CredentialRequestSignal
        {
            if ((object) t == null)
                return t;

            t.onAccessExpired = action;

            return t;
        }
        public static T OnRefreshExpired<T>(this T t, CredentialCallback action) where T : CredentialRequestSignal
        {
            if ((object) t == null)
                return t;

            t.onRefreshExpired = action;

            return t;
        }
    }
}
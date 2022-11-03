#if !NET_LEGACY

using System.Text;
using System.Collections.Specialized;
using System.Net;

using UnityEngine;
using UnityEngine.Networking;
using System;

public class HttpQSCollection : NameValueCollection
{
    public override string ToString()
    {
        int count = Count;
        if (count == 0)
            return "";
        StringBuilder sb = new StringBuilder();
        string[] keys = AllKeys;
        for (int i = 0; i < count; i++)
        {
            sb.AppendFormat("{0}={1}&", keys[i], WebUtility.UrlEncode(this[keys[i]]));
        }
        if (sb.Length > 0)
            sb.Length--;
        return sb.ToString();
    }
}

public class HttpUtility
{
    public static HttpQSCollection ParseQueryString(string str)
    {
        return new HttpQSCollection();
    }

    public static UploadHandlerRaw HandleData<T>(T data)
    {
        var json = JsonUtility.ToJson(data);
        return new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
    }
}
#endif
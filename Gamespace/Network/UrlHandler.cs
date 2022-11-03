using System;
using System.Collections.Specialized;
using Zenject;

namespace Gamespace.Network.RestAPI
{
    public class UrlHandler
    {
        [Inject] private NetworkSettings _settings;
        public string Handle(string segments, NameValueCollection query = null)
        {
            if (query == null)
                query = HttpUtility.ParseQueryString(string.Empty);
            string format;
            string formattedSegments;

            if (_settings.neededVersion)
            {
                format = "/{0}/{1}";
                formattedSegments = string.Format(format,_settings.apiVersion.Value, segments);
            }
            else
            {
                format = "/{0}";
                formattedSegments = string.Format(format, segments);
            }
            
            var uriBuilder = new UriBuilder(_settings.urlGateWay.Value);
            uriBuilder.Path = formattedSegments;
            uriBuilder.Query = query.ToString();
            
            if (_settings.neededPort)
                uriBuilder.Port = _settings.apiPort.Value;

            // FIXME: replacing "ws" with "http" is too hacky!
            uriBuilder.Scheme = uriBuilder.Scheme.Replace("ws", "http");

            return uriBuilder.ToString();
        }
    }
}
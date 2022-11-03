using System;

namespace Gamespace.Network
{
    [Serializable]
    public class NetOperationError
    {
        public int statusCode;
        public string error;
        public string message;

        public string ToString()
        {
            return $"Status Code:{statusCode}\nError:{error}\nMessage:{message}";
        }
        public NetOperationError(){}
        public NetOperationError(NetOperationError netOperationError)
        {
            statusCode = netOperationError.statusCode;
            error = netOperationError.error;
            message = netOperationError.message;
        }
    }
}
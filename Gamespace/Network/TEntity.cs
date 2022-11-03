using System;
using System.Collections.Generic;

namespace Gamespace.Network
{
    public class TEntity<T>
    {
        public T data;
        public NetOperationError error;

        public TEntity(T _data, NetOperationError _errors = null)
        {
            data = _data;
            error = _errors;
        }
    }

    [Serializable]
    public class Empty
    {
        
    }
}
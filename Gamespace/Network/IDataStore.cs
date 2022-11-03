using System.Collections.Specialized;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Gamespace.Network
{
    public interface IDataStore
    {
        UniTask<TEntity<T>> Get<T>(NameValueCollection body, string segments);
        UniTask<TEntity<T>> Post<T>(object body, string segments);
        UniTask<TEntity<T>> Post<T>(NameValueCollection query, object body, string segments);
    }
}
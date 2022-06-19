using UnityEngine;

namespace Infrastructure.Data
{
    public class ResourcesDataProvider : IDataProvider<Object>
    {
        public TData Load<TData>(string path) where TData : Object
        {
            return Resources.Load<TData>(path);
        }
    }
}

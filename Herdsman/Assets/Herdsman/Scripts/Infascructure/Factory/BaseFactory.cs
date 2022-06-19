using Infrastructure.Data;
using UnityEngine;

namespace Infrastructure.Factory
{
    public abstract class BaseFactory : IFactory
    {
        protected virtual IDataProvider<Object> DataProvider { get; private set; }

        public IFactoryContainer Container { get; private set; }

        public void OnRegister(IFactoryContainer container)
        {
            Container = container;
            DataProvider = new ResourcesDataProvider();
    }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IFactory 
    {
        void OnRegister(IFactoryContainer container);
    }
}

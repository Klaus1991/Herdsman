using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Data
{
    public interface IDataProvider<in TBaseType>
    {
        TData Load<TData>(string path) where TData : TBaseType;
    }
}

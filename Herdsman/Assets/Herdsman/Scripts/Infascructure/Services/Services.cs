using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Utils;

namespace Infrastructure.Services
{
    public class Services
    {
        private static Dictionary<Type, IService> AllServices = new Dictionary<Type, IService>();

        public static IService RegisterService(IService service)
        {
            AllServices[service.GetType()] = service;
            return service;
        }

        public static TService Get<TService>() where TService : IService
        {
            var type = typeof(TService);
            if (AllServices.ContainsKey(type))
            {
                return (TService)AllServices[type];
            }
            else
            {
                InternalLogger.Error(type.ToString() + ". " + ErrorDefinations.SERVICE_NOT_FOUND);
                return default(TService);
            }
        }
    }
}

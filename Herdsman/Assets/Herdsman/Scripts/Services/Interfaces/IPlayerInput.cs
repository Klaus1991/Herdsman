using Infrastructure.Services;
using System;
using UnityEngine;

namespace Herdsman.Services
{
    public interface IPlayerInput : IService
    {
        event Action<Vector2> OnClickEvent;
    }
}

using Infrastructure.Models;
using System;

namespace Herdsman.Logic.UI
{
    public interface IMenuSelector : IShow<IMenuSelector>, IHide
    {
        event Action OnStartGame;
    }
}

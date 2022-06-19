using Herdsman.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.UnityContext
{
    public interface ICollideWithYard
    {
        event Action OnCollideYard;

        void CollidWithYard();
    }
}

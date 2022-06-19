using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Models
{
    public interface IProcess
    {
        bool IsActive { get; }

        void Start();

        void Stop();
    }
}

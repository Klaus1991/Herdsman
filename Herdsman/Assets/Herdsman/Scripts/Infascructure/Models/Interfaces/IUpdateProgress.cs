using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Models
{
    public interface IUpdateProgress
    {
        event Action<float> OnProgressUpdated;
    }
}

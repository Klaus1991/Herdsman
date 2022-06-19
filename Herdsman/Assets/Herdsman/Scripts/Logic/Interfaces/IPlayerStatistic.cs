using Herdsman.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Logic
{
    public interface IPlayerStatistic : IProcess
    {
        event Action<Score> OnScoreChange;
    }
}

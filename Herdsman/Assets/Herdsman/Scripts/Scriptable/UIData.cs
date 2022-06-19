using Infrastructure.Data.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Data.Scriptable
{
    [CreateAssetMenu(fileName = "UIData", menuName = "Herdsman/Create new UIData")]
    public class UIData : ScriptableData
    {
        public override string DataPath => "Scriptable/UIData";

        public GameObject GameMenu;
        public GameObject ScoreUI;
    }
}

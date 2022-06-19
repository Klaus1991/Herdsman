using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Models.Requests
{
    public class LoadLevelRequest
    {
        public string SceneName;
        public Action OnLoadAction;
        public bool ShowLoadingUI;
    }
}

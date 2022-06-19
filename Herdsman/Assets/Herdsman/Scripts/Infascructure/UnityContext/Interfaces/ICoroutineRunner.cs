using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.UnityContext
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);

        void StopAllCoroutines();

        void StopCoroutine(Coroutine coroutine);
    }
}

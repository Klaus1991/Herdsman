using Herdsman.UnityContext;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var collideObject = other.gameObject;
        var collideInteractor = collideObject.GetComponent<ICollideWithYard>();
        collideInteractor?.CollidWithYard();
    }
}

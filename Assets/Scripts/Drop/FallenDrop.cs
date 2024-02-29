using System;
using UnityEngine;

public class FallenDrop : MonoBehaviour
{
    public event Action DropPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out PlayerMove player))
            DropPicked?.Invoke();    
    }
}

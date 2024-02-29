using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingDrop : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 250f;
    [SerializeField] private float _rotationSpeedRandomizer = 0.75f;

    private float _startRotationSpeed;

    public event Action<Vector3> DropFallen;

    private void Start() => _startRotationSpeed = Random.Range(_rotationSpeed * _rotationSpeedRandomizer, _rotationSpeed);

    private void FixedUpdate() => transform.Rotate(0, _startRotationSpeed* Time.deltaTime, 0);
       
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            DropFallen?.Invoke(collision.contacts[0].point);
        }
    }
}

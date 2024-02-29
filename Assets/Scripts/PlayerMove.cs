using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";

    [SerializeField] private Transform _cameraCenter;
    [SerializeField] private float _torqueValue = 1f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 500f;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddTorque(_cameraCenter.right * Input.GetAxis(Vertical) * _torqueValue);

        _rigidbody.AddTorque(-_cameraCenter.forward * Input.GetAxis(Horizontal) * _torqueValue);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _lerpSmoothness = 10;

    private Transform _playerTransform;
    private Rigidbody _playerRigidbody;

    private List<Vector3> _velocitiesList = new List<Vector3>();
    private int _listLength = 10;
    private Vector3 _summXZ;

    private void Start()
    {
        _playerTransform = _player.GetComponent<Transform>();
        _playerRigidbody = _player.GetComponent<Rigidbody>();

        CreateVelocityEmptyList();
    }

    private void FixedUpdate()
    {
        _velocitiesList.Add(_playerRigidbody.velocity);
        _velocitiesList.RemoveAt(0);
    }

    private void Update()
    {
        Vector3 summ = Vector3.zero;

        for (int i = 0; i < _velocitiesList.Count; i++)
        {
            summ += _velocitiesList[i];
            _summXZ = new Vector3(summ.x, 0f, summ.z); // при уменьшении или увеличении появляется вертикальная составляющая скорости, от этого скачок. Эта штука убирает скачок
        }

        transform.position = _playerTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_summXZ), Time.deltaTime * _lerpSmoothness);
    }

    private void CreateVelocityEmptyList()
    {
        for (int i = 0; i < _listLength; i++)
        {
            _velocitiesList.Add(Vector3.zero);
        }
    }
}

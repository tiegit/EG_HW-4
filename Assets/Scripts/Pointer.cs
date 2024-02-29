using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private DropsSpawner _dropsSpawner;
    [SerializeField] private Player _player;
    [SerializeField] private float _rotationSmoothness = 5f;

    private Drop _closestDrop;
    private float _offset = 1.2f;
    private bool _isActive;

    private void Start() => _isActive = true;

    private void Update()
    {
        _closestDrop = _dropsSpawner.GetClosestDrop(transform.position);

        if (_closestDrop == null)
        {
            if (_isActive)
                gameObject.SetActive(false);
            
            return;
        }

        Debug.DrawLine(transform.position, _closestDrop.transform.position);

        Vector3 toTarget = _closestDrop.transform.position - transform.position;
        Vector3 toTargetXZ = new Vector3(toTarget.x, 0, toTarget.z);

        //transform.rotation = Quaternion.LookRotation(toTargetXZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(toTargetXZ), Time.deltaTime * _rotationSmoothness);


        Vector3 playerPosition = _player.transform.position;
        float playerPositionY = playerPosition.y * 2 * _offset;

        Vector3 position = new Vector3(playerPosition.x, playerPositionY, playerPosition.z);
        transform.position = position;
    }
}

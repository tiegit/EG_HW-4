using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsSpawner : MonoBehaviour
{
    [SerializeField] private Drop _dropPrefab;
    [SerializeField] private Collider _spawnCollider;
    [SerializeField] private int _dropsCount;

    private List<Drop> _dropsList = new List<Drop>();
    private float _dropsRadius;
    private bool _isPositionEmpty;

    public int GetDropsListCount => _dropsList.Count;

    private void Start()
    {
        FallingDrop fallingDrop = _dropPrefab.GetComponentInChildren<FallingDrop>();
        _dropsRadius = fallingDrop.GetComponent<SphereCollider>().radius;

        StartCoroutine(CreateDrop());
    }

    private IEnumerator CreateDrop()
    {
        for (int i = 0; i < _dropsCount; i++)
        {
            Bounds bounds = _spawnCollider.bounds;

            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z)
                );

            CheckEmptyPosition(randomSpawnPosition);

            if (_isPositionEmpty)
            {
                Drop drop = Instantiate(_dropPrefab, randomSpawnPosition, Quaternion.identity);

                _dropsList.Add(drop);
            }
            else
                _dropsCount++;
        }

        yield return null;
    }

    private void CheckEmptyPosition(Vector3 randomSpawnPosition)
    {
        if (Physics.OverlapSphere(randomSpawnPosition, _dropsRadius).Length == 1)
            _isPositionEmpty = true;
        else
            _isPositionEmpty = false;        
    }
    
    public Drop GetClosestDrop(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Drop closestDrop = null;

        for (int i = 0; i < _dropsList.Count; i++)
        {
            float distance = Vector3.Distance(point, _dropsList[i].transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestDrop = _dropsList[i];
            }
        }

        return closestDrop;
    }

    public void RemoveDropFromList(Drop drop) =>  _dropsList.Remove(drop);
}

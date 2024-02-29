using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _scaleStep = 0.1f;
    [SerializeField] private float _scaleSmoothness = 10f;

    private Vector3 _playerScale;
    private float _scaleValue;

    private void Start() 
    {
        _playerScale = transform.localScale;
        transform.localScale = _playerScale * _scaleStep;
        //ScalePlayer();

    }   

    public void ScalePlayer()
    {
        _scaleValue += _scaleStep;

        transform.localScale = Vector3.Lerp(transform.localScale, _playerScale * _scaleValue, _scaleSmoothness);
        //transform.localScale =_previousPlayerScale * _scaleValue;
    }
}
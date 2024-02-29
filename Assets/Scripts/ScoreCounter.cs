using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private DropsSpawner _dropsSpawner;
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Canvas _finalCanvas;

    private void Start() => SetCountText();

    public void PickUpDrop(Drop drop)
    {
        _dropsSpawner.RemoveDropFromList(drop);
        _player.ScalePlayer();

        SetCountText();

        CheckDropCount();
    }

    public void SetCountText() => _countText.text = _dropsSpawner.GetDropsListCount.ToString();

    private void CheckDropCount()
    {
        if (_dropsSpawner.GetDropsListCount <= 0)
            Invoke(nameof(FinalAction), 1);
    }

    private void FinalAction()
    {
        _finalCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        //_player.GetComponent<AudioSource>().Stop();
    }
}

using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private FallingDrop _fallingDrop;
    [SerializeField] private FallenDrop _fallenDrop;

     private AudioSource _dropPickedSound;

    private void Start()
    {
        _dropPickedSound = FindObjectOfType<PickUpSound>().GetComponent<AudioSource>();

        _fallingDrop.gameObject.SetActive(true);
        _fallenDrop.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _fallingDrop.DropFallen += OnDropFallen;
        _fallenDrop.DropPicked += OnDropPicked;
    }

    private void OnDisable()
    {
        _fallingDrop.DropFallen -= OnDropFallen;
        _fallenDrop.DropPicked -= OnDropPicked;
    }

    private void OnDropFallen(Vector3 dropPosition)
    {
        transform.position = dropPosition;

        _fallingDrop.gameObject.SetActive(false);
        _fallenDrop.gameObject.SetActive(true);
    }

    private void OnDropPicked()
    {
        _dropPickedSound.Play();

        FindObjectOfType<ScoreCounter>().PickUpDrop(this);

        gameObject.SetActive(false);
        //Destroy(gameObject); // можно и удалить
    }
}

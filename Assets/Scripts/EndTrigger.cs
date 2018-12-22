using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Cheer");
        gameManager.CompleteLevel();
    }
}

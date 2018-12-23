using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<AudioManager>().Play("Crash", 0.5f);
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }

}

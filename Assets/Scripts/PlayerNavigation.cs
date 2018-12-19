using UnityEngine;

public class PlayerNavigation : MonoBehaviour
{
    public GameManager gameManager;
    // Player Navigation
    public void Update()
    {

        if (Input.GetKey("escape"))
        {
            gameManager.goToMainMenu();
        }

        if (Input.GetKey("space"))
        {
            gameManager.RestartGame();
        }

    }
}

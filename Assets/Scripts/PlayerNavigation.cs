using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNavigation : MonoBehaviour
{
    public GameManager gameManager;
    // Player Navigation

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Update()
    {
     
        if (Input.GetKey("escape"))
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            if (SceneManager.GetActiveScene().name == "LevelSelect")
            {
                gameManager.goToWelcomeScene();
            } else
            {
                gameManager.goToMainMenu();
            }

            
        }

        if (Input.GetKey("space"))
        {
            gameManager.RestartGame();
        }

    }
}

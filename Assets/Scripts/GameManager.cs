using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 2.7f;

    public GameObject endGameUI;

    // Poziva se kad igrac neuspjesno zavrsi level
    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            //Invoke("RestartGame", restartDelay);
            endGameUI.SetActive(true);
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Poziva se kad igrac uspjesno zavrsi level
    public void CompleteLevel()
    {
        FindObjectOfType<AudioManager>().Play("Cheer");
        EndGame();
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

  
}

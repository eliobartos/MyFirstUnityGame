using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 2.7f;

    public void EndGame()
    {
        if(!gameHasEnded)
        {
            Debug.Log("End Game!");
            gameHasEnded = true;
            Invoke("RestartGame", restartDelay);
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        EndGame();
    }
}

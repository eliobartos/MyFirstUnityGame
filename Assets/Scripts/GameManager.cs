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
        float timePassed = FindObjectOfType<Timer>().timePassed;
        string activeScene = SceneManager.GetActiveScene().name;

        GiveCubes(timePassed, activeScene);
        GiveHighScore(timePassed, activeScene);
        // Save game after giving score
        SaveLoad.SaveGame();

        FindObjectOfType<AudioManager>().Play("Cheer");
        EndGame();
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // give player cubes for completing level in time
    public void GiveCubes(float timePassed, string levelName)
    {
        // Give cubes for completing level in certain time
        switch (levelName)
        {
            case "Level01":
                if(timePassed <= 13.9f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(0, 3);
                } else if (timePassed <= 15.5f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(0, 2);
                } else if (timePassed <= 18f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(0, 1);
                }
                break;
            case "Level02":
                if (timePassed <= 15.5f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(1, 3);
                    Debug.Log("Won 3 cubes!");
                }
                else if (timePassed <= 17.5f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(1, 2);
                    Debug.Log("Won 2 cubes!");
                }
                else if (timePassed <= 20f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(1, 1);
                    Debug.Log("Won 1 cubes!");
                }
                break;
            case "Level03":
                if (timePassed <= 13.9f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(2, 3);
                }
                else if (timePassed <= 15.5f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(2, 2);
                }
                else if (timePassed <= 18f)
                {
                    SaveLoad.currentGame.AssignCubesPerLevel(2, 1);
                }
                break;
        }

    }

    public void GiveHighScore(float timePassed, string levelName)
    {
        Debug.Log("Inside GiveHighScore");
        switch (levelName)
        {
            case "Level01":
                SaveLoad.currentGame.AssignHighScorePerLevel(0, timePassed);
                break;
            case "Level02":
                SaveLoad.currentGame.AssignHighScorePerLevel(1, timePassed);
                break;
            case "Level03":
                SaveLoad.currentGame.AssignHighScorePerLevel(2, timePassed);
                break;
        }
    }
}

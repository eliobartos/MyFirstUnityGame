using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public bool gameHasEnded = false;
    public float restartDelay = 2.7f;

    public GameObject endGameUI;

    // Poziva se kad igrac neuspjesno zavrsi level
    public void EndGame(bool levelCompleted = false, int newCubes = 0)
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            //Invoke("RestartGame", restartDelay);
            //Activate UI
            EndGameUIStars();
            endGameUI.SetActive(true);
            EndGameUISuccess(levelCompleted);
            Debug.Log(newCubes);
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Poziva se kad igrac uspjesno zavrsi level
    public void CompleteLevel()
    {
        int newCubes = 0;
        float timePassed = FindObjectOfType<Timer>().timePassed;
        string activeScene = SceneManager.GetActiveScene().name;

        newCubes = GiveCubes(timePassed, activeScene);
        GiveHighScore(timePassed, activeScene);
        // Save game after giving score
        SaveLoad.SaveGame();

        FindObjectOfType<AudioManager>().Play("Cheer");
        EndGame(true, newCubes);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void goToWelcomeScene()
    {
        SceneManager.LoadScene("WelcomeScene");
    }

    // give player cubes for completing level in time
    public int GiveCubes(float timePassed, string levelName)
    {
        int newCubes = 0;
        // Give cubes for completing level in certain time
        switch (levelName)
        {
            case "Level01":
                if(timePassed <= 13.9f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(0, 3);
                } else if (timePassed <= 15.5f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(0, 2);
                } else if (timePassed <= 18f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(0, 1);
                }
                break;
            case "Level02":
                if (timePassed <= 15.5f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(1, 3);
                    Debug.Log("Won 3 cubes!");
                }
                else if (timePassed <= 17.5f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(1, 2);
                    Debug.Log("Won 2 cubes!");
                }
                else if (timePassed <= 20f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(1, 1);
                    Debug.Log("Won 1 cubes!");
                }
                break;
            case "Level03":
                if (timePassed <= 13.9f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(2, 3);
                }
                else if (timePassed <= 15.5f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(2, 2);
                }
                else if (timePassed <= 18f)
                {
                    newCubes = SaveLoad.currentGame.AssignCubesPerLevel(2, 1);
                }
                break;
        }
        return newCubes;

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


    public void EndGameUIStars()
    {
        int levelIndex = 0;
        string levelName = SceneManager.GetActiveScene().name;
        GameObject starContainer = null;
        int stars;

        switch(levelName)
        {
            case "Level01":
                levelIndex = 0;
                break;
            case "Level02":
                levelIndex = 1;
                break;
            case "Level03":
                levelIndex = 2;
                break;
        }
        
        foreach(Transform e in endGameUI.transform)
        {
            if (e.name != "StarContainer")
                continue;

            starContainer = e.gameObject;
        }

        stars = SaveLoad.currentGame.cubesPerLevel[levelIndex];
        EnableStarsOnStarContainer(starContainer, levelIndex, stars);
        
    }

    public void EnableStarsOnStarContainer(GameObject starContainer, int levelIndex, int stars)
    {
        int i = 1;
        foreach (Transform star in starContainer.transform)
        {
            foreach (Transform image in star.transform)
            {
                if (SaveLoad.currentGame.cubesPerLevel[levelIndex] >= i)
                {
                    image.gameObject.SetActive(true);
                }

            }
            ++i;

        }
    }

    public void EndGameUISuccess(bool levelCompleted)
    {
        foreach (Transform t in endGameUI.transform)
        {
            Debug.Log(t.name);
            if(t.name == "Failed" && levelCompleted == false)
            {
                t.gameObject.SetActive(true);
            } else if (t.name == "Success" && levelCompleted == true)
            {
                t.gameObject.SetActive(true);
            }

        }
    }
}

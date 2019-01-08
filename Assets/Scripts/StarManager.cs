using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{

    public GameObject[] levelButtons;

    public void Start()
    {
        Debug.Log(SaveLoad.GetTotalStars());
        LoadLevels();
    }

    public void LoadLevels()
    {
        int totalStars = SaveLoad.GetTotalStars();
        
        for (int i = 0; i < levelButtons.Length; ++i)
        {

            int currentLevel = int.Parse(levelButtons[i].transform.GetChild(0).transform.GetComponent<Text>().text);
            int currentLevelRequirement = LevelUnlockRequirement(currentLevel);

            // If level is unlocked
            if(totalStars >= currentLevelRequirement)
            {
                // Set button as interactable
                levelButtons[i].GetComponent<Button>().interactable = true;

                // Load stars
                EnableStarsOnLevel(i, SaveLoad.currentGame.cubesPerLevel[i]);
            } else
            {
                EnableStarsRequirement(i);
            }

            
            
        }
        
    }
    
    public void EnableStarsOnLevel(int levelIndex, int stars)
    {
        foreach (Transform element in levelButtons[levelIndex].transform)
        {

            if (element.name != "StarContainer")
                continue;

            // activate game object
            element.transform.gameObject.SetActive(true);

            // Handle stars
            int i = 1;
            foreach (Transform star in element.transform)
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
    }

    public void EnableStarsRequirement(int levelIndex)
    {
        foreach (Transform element in levelButtons[levelIndex].transform)
        {
            if (element.name != "LockedLevel")
                continue;

        
            element.gameObject.SetActive(true);
            // Set stars requirement
            element.GetComponentInChildren<Text>().text = LevelUnlockRequirement(levelIndex + 1).ToString();

        }
    }

    public int LevelUnlockRequirement(int currentLevel)
    {
        switch(currentLevel) {
            case 1:
                return (0);
            case 2:
                return (1);
            case 3:
                return (3);
        }
        return (0);
    }
}

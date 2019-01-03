using UnityEngine;

public class StarManager : MonoBehaviour
{

    public GameObject[] levelButtons;

    public void Start()
    {
        LoadLevelStars();
    }

    public void LoadLevelStars()
    {
        for(int i = 0; i < levelButtons.Length; ++i)
        {
            EnableStarsOnLevel(i, SaveLoad.currentGame.cubesPerLevel[i]);
        }

    }

    public void EnableStarsOnLevel(int levelIndex, int stars)
    {
        foreach (Transform starContainer in levelButtons[levelIndex].transform)
        {

            if (starContainer.name != "StarContainer")
                continue;

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
    }

}

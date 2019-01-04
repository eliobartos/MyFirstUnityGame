using System.Collections;
using UnityEngine;

[System.Serializable]
public class GameData
{
    private readonly int levelNum = 3;
    public int[] cubesPerLevel;  // number of cubes per level user has
    public float[] highScorePerLevel;  // fastest time per level

    public GameData()
    {
        this.cubesPerLevel = new int[levelNum];
        this.highScorePerLevel = new float[levelNum];

        for (int i = 0; i < levelNum; i++)
        {
            this.cubesPerLevel[i] = 0;
            this.highScorePerLevel[i] = 99f;
        }

    }

    public void Print()
    {
        Debug.Log("Cubes per level -----------------");
        for(int i = 0; i < levelNum; i++)
        {
            Debug.Log("Level " + (i + 1).ToString() + " cubes collected " + this.cubesPerLevel[i]);
        }

        Debug.Log("High Scores -----------------");
        for (int i = 0; i < levelNum; i++)
        {
            Debug.Log("Level " + (i + 1).ToString() + " fastest time " + this.highScorePerLevel[i]);
        }
    }

    // Assing new cubes if user doesn't allready have them
    public int AssignCubesPerLevel(int index, int value)
    {
        int newCubes = 0;
        if(cubesPerLevel[index] < value)
        {
            newCubes = value - cubesPerLevel[index];
            cubesPerLevel[index] = value;

        }
        return newCubes;
    }

    public void AssignHighScorePerLevel(int index, float time)
    {
        if(highScorePerLevel[index] > time)
        {
            highScorePerLevel[index] = time;
        }
    }
}
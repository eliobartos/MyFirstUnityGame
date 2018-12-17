using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameManager gameManager;
    private float timePassed;

    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameHasEnded)
        {
            timePassed += Time.deltaTime;
        }

        timerText.text = timePassed.ToString("F2") + " s";
    }
}
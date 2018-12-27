using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour
{
    public void ClickOnButton()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClicked");
        SceneManager.LoadScene("LevelSelect");
    }    
}

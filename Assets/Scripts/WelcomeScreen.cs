using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour
{
    public void ClickOnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }    
}

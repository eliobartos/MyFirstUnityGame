using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenu : MonoBehaviour
{
    // Called when button on Main Menu is clicked
    public void loadLevel()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClicked");

        string buttonTag = EventSystem.current.currentSelectedGameObject.tag;

        if(buttonTag == "Lvl1")
        {
            SceneManager.LoadScene("Level01");
        }
        else if (buttonTag == "Lvl2")
        {
            SceneManager.LoadScene("Level02");
        }
        else if (buttonTag == "Lvl3")
        {
            SceneManager.LoadScene("Level03");
        }
        else if (buttonTag == "Controls")
        {
            SceneManager.LoadScene("Controls");
        }
        else if (buttonTag == "Quit")
        {
            Application.Quit();
        }
        
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //functions to start or end the game based on button pressed
    private void Start()
    {
        Cursor.visible = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        //On hitting Quit Game, the game quits.
        Application.Quit();
    }
}

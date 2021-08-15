using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>PlayButton on click loads the maze scene </summary>
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze", LoadSceneMode.Single);
    }

    /// <summary>QuitButton on click quits game</summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}

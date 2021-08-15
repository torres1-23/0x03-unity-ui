using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>PlayButton on click load the maze scene </summary>
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze", LoadSceneMode.Single);
    }
}

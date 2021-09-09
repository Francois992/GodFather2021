using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string gameScene;
    public GameObject controlsPanel;

    public void StartGame()
    {
      SceneManager.LoadScene("Game");
    }

    public void OpenControls()
    {
      controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
      controlsPanel.SetActive(false);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
}

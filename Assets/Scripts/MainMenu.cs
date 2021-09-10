using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string gameScene;
    public GameObject controlsPanel;
    public GameObject optionsPanel;

    public void StartGame()
    {
      SceneManager.LoadScene("MainScene");
    }

    public void OpenControls()
    {
      controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
      controlsPanel.SetActive(false);
    }

    public void OpenOptions()
    {
      optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
      optionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
      Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void GoToMainMenu()
    {
      SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
      SceneManager.LoadScene("MainScene");
    }
}

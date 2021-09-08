using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void GoToMainMenu()
    {
      SceneManager.LoadScene("Maxence");
    }

    public void Retry()
    {
      SceneManager.LoadScene("Game");
    }
}

using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas gameplayCanvas;
    [SerializeField] GameObject pauseMenu;

    public void PauseGame()
    {
        gameplayCanvas.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameplayCanvas.gameObject.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference pause;
    [SerializeField] private GameObject pauseOverlay;
    static bool gamePaused = false;

    void Start()
    {
        pause.action.performed += OnPause;
    }
    public void PauseGame()
    { Debug.Log("Game Paused");
        gamePaused = !gamePaused;
        if (gamePaused)
        {
            Time.timeScale = 0;
            pauseOverlay.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseOverlay.gameObject.SetActive(false);
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        PauseGame();
    }
    private void OnDestroy()
    {
        pause.action.performed -= OnPause;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

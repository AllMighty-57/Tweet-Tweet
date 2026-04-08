using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 
    public GameObject audioMenuUI; 
    public GameObject MenuButton;
    
    public void OnButtonClicked()
    {
        if (!GameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false; 
        MenuButton.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true; 
        MenuButton.SetActive(false);
    } 
    public void LoadMenu()
    {
        Debug.Log("Back to Menu");
    } 
    public void QuitGame()
    {
        Debug.Log("Get outta HERE!");
    } 

    public void Audio()
    {
        audioMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    } 
    public void backToPauseMenu()
    {
        audioMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}

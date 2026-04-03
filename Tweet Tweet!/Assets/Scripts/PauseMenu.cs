using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 
    public GameObject audioMenuUI;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused )
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    } 
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
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

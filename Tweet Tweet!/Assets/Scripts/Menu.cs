using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startLevel()
    {
        SceneManager.LoadScene("Level 1");
    } 
    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

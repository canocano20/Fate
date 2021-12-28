using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChangeToMain()
    {
        MainMenu.gameObject.SetActive(true);
        Credits.gameObject.SetActive(false);
    }

    public void ChangeToCredits()
    {
        Credits.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
}

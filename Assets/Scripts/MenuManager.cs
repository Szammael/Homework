using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverObject;
    [SerializeField] Timer timer;

    private void Start()
    {
        gameOverObject.SetActive(false);
    }

    public void OnGameEnded()
    {

        gameOverObject.SetActive(true);
        timer.timerIsRunning = false;


    }

    public void Reset()
    {
        SceneManager.LoadScene("Level_1");

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");

    }

    public void Exit()
    {
        Application.Quit();
    }

}



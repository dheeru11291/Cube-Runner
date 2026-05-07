using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject gamePannel;
    public GameObject taptoStart;
    private void Start()
    {
        PouseGame();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            StartGame();
            taptoStart.SetActive(false);
        }
    }
    public void GameOver()
    {
        gamePannel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void PouseGame()
    {
        Time.timeScale = 0f;
    }
    void StartGame()
    {
        Time.timeScale = 1f;
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevelCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject stopPanel;
    [SerializeField] GameObject gamePausedTxt;



    private void Start()
    {
        stopPanel.SetActive(false);
        gamePausedTxt.SetActive(false);
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGame();
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        
    }

    public void ContinueButton()
    {
        Time.timeScale = 1;
    }
}

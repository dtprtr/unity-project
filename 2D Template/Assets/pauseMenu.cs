using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
     Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quiting...");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainMenu");
    }
}


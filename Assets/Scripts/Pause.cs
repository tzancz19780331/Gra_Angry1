using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Pause : MonoBehaviour {

    public GameObject pauseObj;
    private float tempTimeScale;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale != 0)
            {
                tempTimeScale = Time.timeScale;
            }
            PauseGame();
        }
    }

    void PauseGame()
    {
        pauseObj.SetActive(!pauseObj.activeInHierarchy);
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }else
        {
           Time.timeScale = tempTimeScale; 
        } 
    }

    public void ResumeButton()
    {
        PauseGame();
    }

    public void MenuExitButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
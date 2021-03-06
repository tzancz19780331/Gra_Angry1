using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuFunctionality : MonoBehaviour {

    public Light redLight;
    public Light blueLight;
    public float lightDelay;
    private float delay;

    public GameObject highScores;
    public GameObject menuButtons;

    void Start()
    {
        delay = lightDelay;
        redLight.enabled = true;
        blueLight.enabled = false;

        if(PlayerPrefsX.GetIntArray("HighScoreArray", 0, 10)[0] == 0)
        {
            int[] highScoresInitializationArray = new int[10] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
           PlayerPrefsX.SetIntArray("HighScoreArray", highScoresInitializationArray);
        }
    }

    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            redLight.enabled = !redLight.enabled;
            blueLight.enabled = !blueLight.enabled;
            delay = lightDelay;
        }
    }

    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void HighScoresButton()
    {
        GameObject.Find("Menu").SetActive(false);
        highScores.SetActive(true);
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void GoBackButton()
    {
        highScores.SetActive(false);
        menuButtons.SetActive(true);
    }
}
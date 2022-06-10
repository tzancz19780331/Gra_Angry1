using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGame : MonoBehaviour {

    public Text gainedPointsText;
    public Text extraLifesBonusText;
    public Text noCollisionBonusText;
    public Text altogetherPointsText;

    public int everyExtraLifeBonus;
    public int noCollisionBonus;

    private GameObject GameManager;
    private GameObject RedCar;

    private int score;
    private int [] HighScoresArray = new int[10];

    void Start () {
        //HighScoresArray = PlayerPrefsX.GetIntArray("HighScoreArray");
        gainedPointsText.text = PointsManager.points.ToString();
        GameManager = GameObject.Find("Game Manager");
        extraLifesBonusText.text = (GameManager.GetComponent<CarDurabilityManager>().lifes * everyExtraLifeBonus).ToString();
        if((RedCar = GameObject.FindWithTag("Player")) != null)
        {
            if (RedCar.GetComponent<RedCarMovement>().durability == RedCar.GetComponent<RedCarMovement>().maxDurability && GameManager.GetComponent<CarDurabilityManager>().lifes == GameManager.GetComponent<CarDurabilityManager>().maxLifes)
            {
                noCollisionBonusText.text = noCollisionBonusText.ToString();
            }
        }

        altogetherPointsText.text = (int.Parse(gainedPointsText.text) + int.Parse(extraLifesBonusText.text) + int.Parse(noCollisionBonusText.text)).ToString();
        score = int.Parse(altogetherPointsText.text);
        if(score > HighScoresArray[9])
        {
            for(int i = 0; i<10; i ++)
            {
                if(score > HighScoresArray[i])
                {
                    for(int j=9; j>i; j--)
                    {
                        HighScoresArray[j] = HighScoresArray[j-1];
                    }
                    HighScoresArray[i] = score;
                    break;
                }
            }
        }

        PlayerPrefsX.SetIntArray("HighScoreArray", HighScoresArray);
    }


    public void RetryButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void MenuExitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}

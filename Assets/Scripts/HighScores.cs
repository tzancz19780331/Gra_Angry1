using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScores : MonoBehaviour {

    public Text highScoresText;
    int[] highScoresArray = new int[10];

    void Start()
    {
        highScoresArray = PlayerPrefsX.GetIntArray("HighScoreArray");
        if(highScoresArray[0] == 0)
        {
            highScoresText.text = "BRAK WYNIKOW!";
        } else
        {
            highScoresText.text = "";
            for(int i = 0; highScoresArray[i] != 0; i++)
            {
                highScoresText.text += (i + 1) + ". " + highScoresArray[i] + "Pkt" + System.Environment.NewLine;
                if(i == 9)
                {
                    break;
                }
            }
        }
    }

}
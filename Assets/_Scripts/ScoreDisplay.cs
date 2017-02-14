using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public Text playerName;
    public Text[] rollTexts;
    public Text[] frameTexts;

	public void Clear()
    {
        foreach (Text text in rollTexts)
        {
            text.text = "";
        }

        foreach (Text text in frameTexts)
        {
            text.text = "";
        }
    }

    public void SetPlayerName(string name)
    {
        playerName.text = name;
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);
        //for (int i = 0; i < rolls.Count; i++)
        for (int i = 0; i < scoreString.Length; i++)
        {
            //rollTexts[i].text = FormatRolls(rolls)[i].ToString();
            rollTexts[i].text = scoreString[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++)
        {
            int roll = output.Length + 1;

            if (rolls[i] == 0)                                                          //GUTTERBALL
            {
                output += "-";
            }
            else if ((roll % 2 == 0 || roll == 21) && rolls[i - 1] + rolls[i] == 10)    //SPARE
            {
                output += "/";
            }
            else if (roll >= 19 && rolls[i] == 10)                                      //STRIKE in last frame
            {
                output += "X";
            }   
            else if (rolls[i] == 10)                                                    //STRIKE
            {
                output += "X ";
            }
            else                                                                        //Normal 1-9 roll
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }
}

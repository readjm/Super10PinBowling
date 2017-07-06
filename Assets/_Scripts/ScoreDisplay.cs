using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public Text playerName;
    public Text[] rollTexts;
    public Text[] frameTexts;

    private BowlMessageDisplay bowlMessageDisplay;
    private static int strikeCount = 0;

    void Start()
    {
        if (GameObject.FindObjectOfType<BowlMessageDisplay>())
        {
            bowlMessageDisplay = GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>();
        }
    }
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

    public void FillRolls(List<int> rolls, bool newBowl)
    {
        string scoreString = FormatRolls(rolls, newBowl);
        //for (int i = 0; i < rolls.Count; i++)
        for (int i = 0; i < scoreString.Length; i++)
        {
            //rollTexts[i].text = FormatRolls(rolls)[i].ToString();
            rollTexts[i].text = scoreString[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls, bool newBowl)
    {
        string output = "";
        
        for (int i = 0; i < rolls.Count; i++)
        {
            int roll = output.Length + 1;

            if (rolls[i] == 0)                                                          //GUTTERBALL
            {
                output += "-";
                if (i == rolls.Count - 1 && newBowl)
                {
                    strikeCount = 0;
                    GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.GUTTERBALL);
                }
            }
            else if ((roll % 2 == 0 || roll == 21) && rolls[i - 1] + rolls[i] == 10)    //SPARE
            {
                output += "/";
                if (i == rolls.Count - 1 && newBowl)
                {
                    strikeCount = 0;
                    GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.SPARE);
                }
            }
            else if (roll >= 19 && rolls[i] == 10)                                      //STRIKE in last frame
            {
                output += "X";
                if (i == rolls.Count - 1 && newBowl)
                {
                    strikeCount++;
                    if (strikeCount == 1) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.STRIKE);
                    if (strikeCount == 2) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.DOUBLE);
                    if (strikeCount >= 3) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.TURKEY);
                }
            }   
            else if (rolls[i] == 10)                                                    //STRIKE
            {
                output += "X ";
                if (i == rolls.Count - 1 && newBowl)
                {
                    strikeCount++;
                    if (strikeCount == 1) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.STRIKE);
                    if (strikeCount == 2) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.DOUBLE);
                    if (strikeCount >= 3) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.TURKEY);
                }
            }
            else                                                                        //Normal 1-9 roll
            {
                output += rolls[i].ToString();
                if (i == rolls.Count - 1 && newBowl)
                {
                    strikeCount = 0;
                }
            }
        }


        return output;
    }
}

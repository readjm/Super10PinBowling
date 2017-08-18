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

    public void FillRolls(Player player, bool newBowl)
    {
        string scoreString = FormatRolls(player, newBowl);
        for (int i = 0; i < scoreString.Length; i++)
        {
            rollTexts[i].text = scoreString[i].ToString();
        }
    }

    public static string FormatRolls(Player player, bool newBowl)
    {
        string output = "";
        
        for (int i = 0; i < player.rolls.Count; i++)
        {
            int roll = output.Length + 1;

            if (player.rolls[i] == 0)                                                          //GUTTERBALL
            {
                output += "-";
                if (i == player.rolls.Count - 1 && newBowl)
                {
                    player.strikeCounter = 0;
                    GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.GUTTERBALL);
                }
            }
            else if ((roll % 2 == 0 || roll == 21) && player.rolls[i - 1] + player.rolls[i] == 10)    //SPARE
            {
                output += "/";
                if (i == player.rolls.Count - 1 && newBowl)
                {
                    player.strikeCounter = 0;
                    GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.SPARE);
                }
            }
            else if (roll >= 19 && player.rolls[i] == 10)                                      //STRIKE in last frame
            {
                output += "X";
                if (i == player.rolls.Count - 1 && newBowl)
                {
                    player.strikeCounter++;
                    if (player.strikeCounter == 1) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.STRIKE);
                    if (player.strikeCounter == 2) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.DOUBLE);
                    if (player.strikeCounter >= 3) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.TURKEY);
                }
            }   
            else if (player.rolls[i] == 10)                                                    //STRIKE
            {
                output += "X ";
                if (i == player.rolls.Count - 1 && newBowl)
                {
                    player.strikeCounter++;
                    if (player.strikeCounter == 1) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.STRIKE);
                    if (player.strikeCounter == 2) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.DOUBLE);
                    if (player.strikeCounter >= 3) GameObject.FindObjectOfType<BowlMessageDisplay>().GetComponent<BowlMessageDisplay>().PlayMessage(BowlMessageDisplay.BowlMessage.TURKEY);
                }
            }
            else                                                                        //Normal 1-9 roll
            {
                output += player.rolls[i].ToString();
                if (i == player.rolls.Count - 1 && newBowl)
                {
                    player.strikeCounter = 0;
                }
            }
        }


        return output;
    }
}

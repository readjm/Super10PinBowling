using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public Text textPrefab;

    private static List<Player> players = new List<Player>();
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;
    private int playerTurn = 1;

    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        TouchScreenKeyboard.hideInput = true;

        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();

        if (players.Count != 0)
        {
            scoreDisplay.SetPlayerName(players[playerTurn - 1].playerName);
        }
    }

    //public void SetNumberOfPlayers(int numPlayers)
    //{
    //    players = new Player[numPlayers];
    //    for (int i = 0; i < players.Length; i++)
    //    {
    //        players[i] = new Player();
    //    }
    //}

    public void AddPlayer(Text playerName)
    {
        Player newPlayer = new Player();
        newPlayer.playerName = playerName.text;
        players.Add(newPlayer);
    }

    public void Bowl(int pinFall)
    {
        players[playerTurn-1].rolls.Add(pinFall);

        scoreDisplay.SetPlayerName(players[playerTurn - 1].playerName);
        scoreDisplay.FillRolls(players[playerTurn - 1].rolls, true);
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(players[playerTurn - 1].rolls));

        ActionMaster.Action nextAction = ActionMaster.NextAction(players[playerTurn-1].rolls);
        
        if (nextAction == ActionMaster.Action.ENDGAME && playerTurn == players.Count)
        {
            Invoke("EndGame", 5);
            return;
        }
        else if (nextAction == ActionMaster.Action.ENDGAME || nextAction == ActionMaster.Action.ENDTURN)
        {
            nextAction = ActionMaster.Action.ENDTURN;
        }
        
        pinSetter.PerformAction(nextAction);
        //scoreDisplay.SetPlayerName(players[playerTurn - 1].playerName);
        //scoreDisplay.FillRolls(players[playerTurn - 1].rolls, true);
        //scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(players[playerTurn - 1].rolls));

        if (nextAction == ActionMaster.Action.ENDTURN)
        {
            playerTurn++;
            if (playerTurn > players.Count)
            {
                playerTurn = 1;
            }
            Invoke("NextTurn", 5);
            return;
        }
         
        ball.Reset();
    }

    public void SetNumPlayers(int numPlayers)
    {
        for (int i = 1; i <= numPlayers; i++)
        {
            Text newPlayer = Instantiate(textPrefab) as Text;
            newPlayer.text = "P" + i.ToString();
            AddPlayer(newPlayer);
        }

        GameObject.FindObjectOfType<LevelManager>().LoadNextLevel();
    }

    public static List<Player> GetPlayers()
    {
        return players;
    }

    public void ResetGame()
    {
        players.Clear();
    }

    private void NextTurn()
    {
        scoreDisplay.Clear();
        scoreDisplay.SetPlayerName(players[playerTurn-1].playerName);
        scoreDisplay.FillRolls(players[playerTurn - 1].rolls, false);
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(players[playerTurn - 1].rolls));
        ball.Reset();
    }

    private void EndGame()
    {
        levelManager.LoadLevel("End");
    }
}

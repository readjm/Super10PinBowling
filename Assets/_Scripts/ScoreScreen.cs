using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreScreen : MonoBehaviour {

    public ScoreDisplay scoreDisplayPrefab;

    private List<ScoreDisplay> scores = new List<ScoreDisplay>();
    private List<Player> players;

    void Start()
    {
        players = GameManager.GetPlayers();

        for (int i = 0; i < players.Count; i++)
        {
            ScoreDisplay newDisplay = Instantiate(scoreDisplayPrefab, scoreDisplayPrefab.transform) as ScoreDisplay;
            newDisplay.transform.SetParent(transform);
            newDisplay.transform.position += new Vector3(0, -75*i, 0);
            newDisplay.SetPlayerName(players[i].playerName);
            newDisplay.FillRolls(players[i].rolls, false);
            newDisplay.FillFrames(ScoreMaster.ScoreCumulative(players[i].rolls));
            scores.Add(newDisplay);
        }

        Invoke("GameComplete", 3);
    }

    private void GameComplete()
    {
        GameObject.Find("Title").SetActive(false);
    }
}

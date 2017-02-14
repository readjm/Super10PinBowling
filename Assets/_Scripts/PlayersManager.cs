using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayersManager : MonoBehaviour {

    public Text textPrefab;
    public Button addButton;
    public Button doneButton;
    public Button removeButtonPrefab;
    public Button renameButtonPrefab;

    private List<Text> players = new List<Text>();
    private TouchScreenKeyboard keyboard;
    private Text newPlayer;
    private bool gettingName;

    void Start()
    {
        //keyboard = new TouchScreenKeyboard("", TouchScreenKeyboardType.Default, false, false, false, false, "P" + players.Count.ToString());
        doneButton.enabled = false;
    }

    void Update()
    {
        if (keyboard != null && keyboard.done && gettingName == true)
        {
            gettingName = false;
            Done(keyboard.text);
        }
    }

    public void AddPlayer()
    {
        addButton.transform.position += new Vector3(0, -76, 0);
        addButton.enabled = false;
        if (doneButton.enabled == false)
        {
            doneButton.enabled = true;
        }
        if (players.Count > 0)
        {
            doneButton.transform.position += new Vector3(0, -76, 0);
        }

        gettingName = true;
        TouchScreenKeyboard.hideInput = true;
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false, "P" + players.Count.ToString());
        TouchScreenKeyboard.hideInput = true;
    }

    public void AddPlayer(Text player)
    {
        Text newPlayer = Instantiate(textPrefab, textPrefab.transform) as Text;
        newPlayer.transform.SetParent(transform);
        newPlayer.text = player.text;
        newPlayer.transform.position += new Vector3(0, -76*(players.Count), 0);
        players.Add(newPlayer);

    }

    public void Done(string text)
    {
        newPlayer = Instantiate(textPrefab, transform) as Text;
        newPlayer.transform.SetParent(transform);
        newPlayer.text = text;
        newPlayer.transform.position += new Vector3(0, -76 * (players.Count), 0);

        addButton.enabled = true;
        players.Add(newPlayer);
        doneButton.enabled = false;
    }

    public void RemovePlayer(int index)
    {
        players.RemoveAt(index);
    }

    public void RemovePlayer(Text text)
    {
        players.Remove(text);
    }
}

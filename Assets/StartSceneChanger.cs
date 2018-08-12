using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class PlayerD
{
    public int score;
    public string name;

    public PlayerD(string name, int score)
    {
        this.score = score;
        this.name = name;
    }

    public int CompareTo(PlayerD comparePart)
    {
        return score - comparePart.score;
    }

}

public class StartSceneChanger : MonoBehaviour {

    public int countOfPlayers = 10;

    public static string currentName = "";

    List<PlayerD> players = new List<PlayerD>();
    

    public Text text;

    // Use this for initialization
    void Start () {
        PlayerController.score = 0;
        for (int i = 0; i < countOfPlayers; i++)
        {
            players.Add(new PlayerD(PlayerPrefs.GetString("Player" + i),PlayerPrefs.GetInt("Score" + i)));
        }

        players.Add(new PlayerD(PlayerPrefs.GetString("NewPlayer"), PlayerPrefs.GetInt("NewScore")));

        players.Sort((delegate (PlayerD p1, PlayerD p2)
        {
            return (p2.score - p1.score);
        }));

        text.text = "";

        foreach (PlayerD pd in players) 
        {
            text.text += pd.name + " " + pd.score + "\n";
        }

        for (int i = 0; i < countOfPlayers; i++)
        {
            PlayerPrefs.SetString("Player" + i, players[i].name);
            PlayerPrefs.SetInt("Score" + i, players[i].score);
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(1);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class PlayerData
{
    public string name;
    public int score;

    public PlayerData(string name,int score)
    {
        this.name = name;
        this.score = score;
    }
}

public class Container : MonoBehaviour {

    List<PlayerData> players = new List<PlayerData>();

    public string namePlayer = null;
    int scorePlayer;

    string path = "Assets/test.txt";

    public Text scoreField;

    public TextAsset asset;

    public InputField mainInputField;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);

        
        mainInputField.onEndEdit.AddListener(delegate { LockInput(mainInputField); });

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        scoreField.text = " ";

        for (int i = 0; i < 10; i++)
        {
            players.Add(new PlayerData(reader.ReadLine(), int.Parse(reader.ReadLine())));
            scoreField.text += players[i].name + " " + players[i].score + System.Environment.NewLine;
        }
        reader.Close();
    }
	
	// Update is called once per frame
	void Update () {
		if(namePlayer != null)
        {
            if(SceneManager.GetActiveScene().name == "Menu")
            {
                StreamWriter writer = new StreamWriter(path, true);
                scoreField.text = " ";
                for(int i = 0;i < 10;i++)
                {
                    scoreField.text += players[i].name + " " + players[i].score + System.Environment.NewLine;
                    writer.WriteLine(players[i].name);
                    writer.WriteLine(players[i].score);
                }
                writer.Close();
            }
        }

        if(Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }


    // Checks if there is anything entered into the input field.
    void LockInput(InputField input)
    {
        if (input.text.Length > 0)
        {
            namePlayer = input.text;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Linq; // library for sorting and searching
using System;
using System.Xml.Serialization;

public class GameOverSceneManager : MonoBehaviour
{

    public TMP_Text highScoreTableText;

    private string highScoresFilePath;


    // Start is called before the first frame update
    void Start()
    {
        highScoresFilePath = Application.persistentDataPath + "/highscores.xml";

        int newScore = PlayerPrefs.GetInt("CurrentScore", 0);
        UpdateHighScores("Player1", newScore);
        DisplayHighScores();
    }
        
    private void UpdateHighScores(string playerName, int newScore)
    {
        HighScores highScores = LoadHighScores();

        highScores.highScoreList.Add(new HighScore(playerName, newScore));

        highScores.highScoreList = highScores.highScoreList
            .OrderByDescending(hs => hs.score) //using Linq library 
            .Take(10)
            .ToList();

        SaveHighScores(highScores);
    }

    

    private HighScores LoadHighScores()
    {
        HighScores highScores;

        if (File.Exists(highScoresFilePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(HighScores));

            using (FileStream stream = new FileStream(highScoresFilePath, FileMode.Open))
            {
                highScores = serializer.Deserialize(stream) as HighScores;
            }
        }
        else
        {
            highScores = new HighScores(); // if file does not exsist create a new list and use that instead
        }
        return highScores;
    }

    private void SaveHighScores(HighScores highScores)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(HighScores));

        using (FileStream stream = new FileStream(highScoresFilePath, FileMode.Create))
        {
            serializer.Serialize(stream, highScores);
        }
    }

    private void DisplayHighScores()
    {
        HighScores highScores = LoadHighScores();
        string displayText = "High Scores:\n";
        int i = 0;
        foreach (var highScore in highScores.highScoreList)
        {
            i++;
            displayText += i + ": " + highScore.playerName + ": " + highScore.score + "\n";
        }
        highScoreTableText.text = displayText;
    }

    public void newGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
}

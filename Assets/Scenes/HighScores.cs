using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class HighScore
{
    public string playerName;
    public int score;

    public HighScore() { }

    public HighScore(string playerName, int score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}

[Serializable]
public class HighScores
{
    public List<HighScore> highScoreList = new List<HighScore>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GameSceneManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject EndGameButton;
    public GameObject UpgradeClickerOne;
    public GameObject UpgradeClickerTwo;
    public GameObject UpgradeClickerThree;
    public int scorePerClick = 1;

    public int currentScore = 0;

    

    public void IncreaseScore()
    {
        currentScore += scorePerClick;
        scoreText.text = "Score: " + currentScore;
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        EndGameButton.SetActive(true);

        if (currentScore >= 10)
        {
            UpgradeClickerOne.SetActive(true);
        }
        if (currentScore >= 100)
        {
            UpgradeClickerTwo.SetActive(true);
        }
        if (currentScore >= 1000)
        {
            UpgradeClickerThree.SetActive(true);
        }
        
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    //public void UpgradeClickOne()
    //{
    //    //scorePerClick += 1;
    //    //currentScore -= 10;
    //    //scoreText.text = "Score: " + currentScore;
    //    if(currentScore <= 10)
    //    {
    //        UpgradeClickerOne.SetActive(false);
    //    }
    //}
    //public void UpgradeClickTwo()
    //{
    //    //scorePerClick += 10;
    //    //currentScore -= 100;
    //   // scoreText.text = "Score: " + currentScore;
    //    if (currentScore <= 100)
    //    {
    //        UpgradeClickerTwo.SetActive(false);
    //    }
    //}
    //public void UpgradeClickThree()
    //{
    //    //scorePerClick += 100;
    //    //currentScore -= 1000;
    //    //scoreText.text = "Score: " + currentScore;
    //    if (currentScore <= 1000)
    //    {
    //        UpgradeClickerThree.SetActive(false);
    //    }
    //}

    public void Upgrade()
    {
        int bonus = 0;
        int cost = 0;
        string buttonName = EventSystem.current.currentSelectedGameObject.name;
        if(buttonName == "UpgradeClickerOne")
        {
            bonus = 1;
            cost = 10;
        }
        if (buttonName == "UpgradeClickerTwo")
        {
            bonus = 10;
            cost = 100;
        }
        if (buttonName == "UpgradeClickerThree")
        {
            bonus = 10;
            cost = 1000;
        }

        scorePerClick += bonus;
        currentScore -= cost;
        scoreText.text = "Score: " + currentScore;

        if (currentScore <= 10)
        {
            UpgradeClickerOne.SetActive(false);
        }
        if (currentScore <= 100)
        {
            UpgradeClickerTwo.SetActive(false);
        }
        if (currentScore <= 1000)
        {
            UpgradeClickerThree.SetActive(false);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;

    public void Start()
    {
        gameOverPanel.SetActive(true);
        if (GameManager.instance)
        {
            scoreText.text = "Score: " + GameManager.instance.score.ToString();
        }

    }
    public void RestartGame()
    {
        //call thi sbeter
        GameManager.instance.Reset();
        SceneManager.LoadScene("Level 1");
    }

}

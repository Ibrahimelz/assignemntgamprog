using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int currentLevel = 1;

    public int highestLevel = 3;
   // public PauseManager;

     void Start()
    {
        
    }
    void Awake()
    {
        
        if (instance == null)
        {
            
            instance = this;
        }
        
        else if (instance != this)
        {
            
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    // Increase score
    public void IncreaseScore(int amount)
    {
       
        score += amount;
       
    }

    public void Reset()
    {

        score = 0;
        
        currentLevel = 1;
        
        
    }

    public void IncreaseLevel()
    {
        if (currentLevel < highestLevel)
        {
            currentLevel++;
            SceneManager.LoadScene("Level " + currentLevel);
        }
        else
        {
            SceneManager.LoadScene("End Scene");
        }
        
    }

    public void ResetCurrScene()
    {
        
        score = 0;
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

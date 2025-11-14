using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject coinCollectEffectPrefab;
    [SerializeField] private int maxHealth = 3;
    private float currentHealth;
    public HudManager hud;
    [SerializeField] private HealthBarScript healthBarScript;
    private CharacterMovement characterMovement;
    private const float boostDur = 5f;
    private const float boostMult= 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        currentHealth = maxHealth;
        hud.Refresh();
        healthBarScript.updateHealthBar(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
		if (transform.position.y < -100.0f)
		{
			currentHealth -= 1;
			if (currentHealth <= 0)
			{
				SceneManager.LoadScene("End Scene");
			}
			else
			{
				healthBarScript.updateHealthBar(maxHealth, currentHealth);
				GameManager.instance.ResetCurrScene();
			}
		}
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseScore(50);
            hud.Refresh();
       
            if (coinCollectEffectPrefab != null)
            {
                Instantiate(coinCollectEffectPrefab, collider.transform.position, Quaternion.identity);
            }
            Destroy(collider.gameObject);

        } else if(collider.gameObject.tag == "Enemy")  {
            currentHealth -= 1;
            if (currentHealth == 0) {
                SceneManager.LoadScene("End Scene");
            } else
            {
                healthBarScript.updateHealthBar(maxHealth, currentHealth);
            }


        } else if(collider.gameObject.tag == "Goal")
        {
            GameManager.instance.IncreaseLevel();
        } else if(collider.gameObject.tag == "Boost")
        {
            StartCoroutine(ApplySpeedBoost(boostMult, boostDur));

            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "JumpTag")
        {
            characterMovement.ActivateDoubleJump();
            Destroy(collider.gameObject);
            
        }


        //detect that we collided with a coin, if that is the case:
        // - play a coin collecting sound
        // - update the score
        // - destroy the coin
    }

    IEnumerator ApplySpeedBoost(float mult, float dur)
    {

        characterMovement.speedMultiplier = mult;
        //Debug.Log($"Speed boost to x{mult} for {dur} seconds");


        yield return new WaitForSeconds(dur);

        characterMovement.speedMultiplier = 1.0f;
        //Debug.Log("Speed boost finished. Speed reset");
    }
}

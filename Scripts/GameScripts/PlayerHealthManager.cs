using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public Text hpCounter;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
          currentHealth = startingHealth;
          rend = GetComponent<Renderer>();
          storedColor = rend.material.GetColor("_Color");
          hpCounter.text = "HP " + currentHealth + "/" + startingHealth;

    }

    // Update is called once per frame
    void Update()
    {


        if(currentHealth <= 0)
        {
          GameObject.Find("Player").transform.localScale = new Vector3(0,0,0);

        }

        if(flashCounter > 0)
        {
          flashCounter -= Time.deltaTime;

          if(flashCounter <= 0)
          {
            rend.material.SetColor("_Color", storedColor);
            }
        }
    }

    public void HurtPlayer(int damageAmount)
    {
      currentHealth -= damageAmount;
      flashCounter = flashLength;
      rend.material.SetColor("_Color", Color.white);
      hpCounter.text = "HP " + currentHealth + "/" + startingHealth;

      //transform HP bar
      GameObject healthBar = GameObject.Find("Player/Canvas/Healthbar/CurrentHealth");
      var healthBarRectTransform = healthBar.transform as RectTransform;
      healthBarRectTransform.sizeDelta = new Vector2 (healthBarRectTransform.sizeDelta.x - 40, healthBarRectTransform.sizeDelta.y);

      //Counteract HP bar Position for HP text
      GameObject playerHP = GameObject.Find("Player/Canvas/Healthbar/CurrentHealth/PlayerHP");
      var playerHPRectTransform = playerHP.transform as RectTransform;
      playerHPRectTransform.sizeDelta = new Vector2 (playerHPRectTransform.sizeDelta.x + 40, playerHPRectTransform.sizeDelta.y);

      if(currentHealth == 0)
      {
        gameOverScreen.SetActive(true);
      }

    }

    public int GetHealth()
    {
      return currentHealth;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public EnemyManger enemyManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            EnemyDestroy();
            Destroy(gameObject);
        }
    }
    public void HurtEnemy(int damage)
    {
      currentHealth -= damage;
    }

    public void EnemyDestroy()
    {
        enemyManager.EnemyDeath();
    }
}

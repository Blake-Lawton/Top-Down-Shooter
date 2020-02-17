using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public int startingEnemies;
    public int enemyCounter;
    public WinScreen winScreen;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCounter <= 0)
        {
            winScreen.WinGame();

            
        }
    }

    public void EnemyDeath()
    {
        enemyCounter -= 1;
    }
}

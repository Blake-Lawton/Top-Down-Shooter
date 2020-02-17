using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealthManager player;
    public GameObject gameOverScreen;
    public GameObject menuButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetHealth() == 0)
        {
            gameOverScreen.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected GameObject
            EventSystem.current.SetSelectedGameObject(menuButton);
        }
    }
}

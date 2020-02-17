using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



public class WinScreen : MonoBehaviour
{
    
    public GameObject winScreen;
    public GameObject nextLevel;
    public int enemyCounter;
    public string nextLevelString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected GameObject
        EventSystem.current.SetSelectedGameObject(nextLevel);
        Time.timeScale = 0f;
    }

    public void NextLevel()
    {
        
        SceneManager.LoadScene(nextLevelString);
        
    }
}

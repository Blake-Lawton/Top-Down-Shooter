using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseController : MonoBehaviour
{
    public string mainMenuScene;
    public GameObject pauseMenu;
    public bool isPaused;
    public GameObject optionsMenu;

    public GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
          if(isPaused)
          {
            ResumeGame();
          }
          else
          {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            //clear selected GameObject
            EventSystem.current.SetSelectedGameObject(null);
            //set a new selected GameObject
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
          }
        }
    }

    public void ResumeGame()
    {
      isPaused = false;
      pauseMenu.SetActive(false);
      optionsMenu.SetActive(false);
      Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        //clear selected GameObject
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected GameObject
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void ApplyChanges()
    {
        ReturnToPauseScreen();

    }

    public void CancelChanges()
    {
        ReturnToPauseScreen();

    }

    public void ReturnToPauseScreen()
    {
      optionsMenu.SetActive(false);
      pauseMenu.SetActive(true);

      EventSystem.current.SetSelectedGameObject(null);
      //set a new selected GameObject
      EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //[SerializeField] private AudioMixer mixer;
    [SerializeField] private List<GameObject> menuButtons = new List<GameObject>();
    private PlayerInput playerInput;
    private bool pauseGame = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {

    }

    private void ButtonsEnableState()
    {
        for (int i = 0; i < menuButtons.Count; i++)
        {
            if (menuButtons[i].CompareTag("SnotCounter") == false)
            {
                menuButtons[i].SetActive(pauseGame);
            }
            
        }
    }

    public void ReturnGame()
    {
        pauseGame = !pauseGame;
        //mixer.SetFloat("LowpassFreq", 22000);
        Time.timeScale = 1f;
        ButtonsEnableState();
        print("Return");
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Exit");
    }

    private void OnPause()
    {
        pauseGame = !pauseGame;

        if (pauseGame)
        {
            //mixer.SetFloat("LowpassFreq", 500);
            Time.timeScale = 0f;
            ButtonsEnableState();

        }

        else if (!pauseGame)
        {
            //mixer.SetFloat("LowpassFreq", 22000);
            Time.timeScale = 1f;
            ButtonsEnableState();
        }
    }
}

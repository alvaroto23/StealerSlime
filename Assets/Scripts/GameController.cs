using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //[SerializeField] private AudioMixer mixer;
    private PlayerInput playerInput;
    private GameObject[] menuButtons = new GameObject[4];
    private bool pauseGame = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        for (int i = 0; i < transform.childCount; i++)
        {
            menuButtons[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Start()
    {

    }

    private void ButtonsEnableState()
    {
        for (int i = 0; i < menuButtons.Length; i++)
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
    }

    public void ExitGame()
    {
        Application.Quit();
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

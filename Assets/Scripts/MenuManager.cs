using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private float duration;
    private Fades fades;

    // Start is called before the first frame update
    void Start()
    {
        fades = GetComponentInChildren<Fades>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(FadeToStartGame());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator FadeToStartGame()
    {
        fades.SetFaded();
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("Level1");

    }
}

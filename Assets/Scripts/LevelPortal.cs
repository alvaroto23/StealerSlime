using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [SerializeField] private CanvasGroup fade;
    private AudioSource audioSource;
    private float t;
    private float duration = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    StartCoroutine(ChangeLevel("Level2"));
                }
                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    StartCoroutine(ChangeLevel("End"));
                }
        }
    }

    private IEnumerator ChangeLevel(string scene)
    {
        while(t< duration)
        {
            fade.alpha = Mathf.Lerp(fade.alpha, 1, t);
            t += Time.deltaTime / duration;
        }

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                StartCoroutine(ChangeToLevel2());
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                StartCoroutine(ChangeLevelEnd());
            }
        }
    }

    private IEnumerator ChangeToLevel2()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level2");
    }
    private IEnumerator ChangeLevelEnd()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("End");
    }
}

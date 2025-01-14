using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnotManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject portal;
    private List<GameObject> coinList = new List<GameObject>();
    private int coins;
    private int totalCoins;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] snotsArray = GameObject.FindGameObjectsWithTag("Snot");
        coinList.AddRange(snotsArray);
        coins = 0;
        totalCoins = coinList.Count;
        score.text = coins.ToString() + " / " + coinList.Count;
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coins == totalCoins && SceneManager.GetActiveScene().name == "Level1")
        {
            portal.SetActive(true);
        }
        else if (coins == totalCoins && SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("End");
        }
        
    }

    public void AddCoin(GameObject coin)
    {
        if (coinList.Contains(coin))
        {
            coinList.Remove(coin);
            coins++;
            score.text = coins.ToString() + " / " + totalCoins;

        }
    }
}

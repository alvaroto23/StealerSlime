using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
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
    }

    // Update is called once per frame
    void Update()
    {
        
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

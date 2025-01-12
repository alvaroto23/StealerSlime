using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private float coins;
    private void Awake()
    {

    }
    void Start()
    {
        coins = 0;
        scoreText.text = coins + " / 5";
    }

    // Update is called once per frame
    void Update()
    {
        if (coins == 5)
        {
            print("caner");
        }
        
    }

    public void AddCoin()
    {
        coins++;
        scoreText.text = coins + " / 5";
    }
}

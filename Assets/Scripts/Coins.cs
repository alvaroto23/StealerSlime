using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Coins : MonoBehaviour
{
    private CoinManager coinManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlayOneShotAudio("");
            coinManager.AddCoin();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        coinManager = GetComponentInParent<CoinManager>();
    }

    void Update()
    {
        
    }
}

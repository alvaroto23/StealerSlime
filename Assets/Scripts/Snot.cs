using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snot : MonoBehaviour
{
    private CoinManager coinManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinManager.AddCoin(gameObject);
            FindObjectOfType<AudioManager>().PlayOneShotAudio("");
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        coinManager = GetComponentInParent<CoinManager>();  
    }

}

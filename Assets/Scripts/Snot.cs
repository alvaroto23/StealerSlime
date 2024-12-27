using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snot : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            Character slime = collision.GetComponent<Character>();
            slime.snots.Add(1);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}

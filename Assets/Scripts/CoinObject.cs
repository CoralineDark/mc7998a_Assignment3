using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinObject : MonoBehaviour
{
    public static event Action PickupCoin; 

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PickupCoin?.Invoke();
            gameObject.SetActive(false); 
        }
    }
}

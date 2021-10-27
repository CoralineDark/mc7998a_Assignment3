using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StarCollectable : MonoBehaviour
{
    public static event Action PickupStar; 
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PickupStar?.Invoke();
            gameObject.SetActive(false); 
        }
    }
}

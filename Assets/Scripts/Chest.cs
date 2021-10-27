using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Chest : MonoBehaviour
{
    public bool chestActive; 
    public GameObject chestSprite;
    public Sprite openSprite; 
    [SerializeField]
    private GameObject lastStar; 
    [SerializeField]
    private GameObject coinSpawner; 
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            chestActive = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            chestActive = false; 
        }
    }

    private void Update() { 
        if (chestActive) {
            if (Input.GetKeyDown(KeyCode.E)) {
                chestSprite.GetComponent<SpriteRenderer>().sprite = openSprite; 
                lastStar.SetActive(true);
                coinSpawner.SetActive(true);
            }
        }
    }
}

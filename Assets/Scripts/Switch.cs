using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Switch : MonoBehaviour
{
    public bool switchActive; 
    public GameObject switchSprite; 
    public static event Action DestroyBarrior;
    private void Start() {
        switchActive = false; 
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            switchActive = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            switchActive = false; 
        }
    }
    private void Update() { 
        if (switchActive) {
            if (Input.GetKeyDown(KeyCode.E)) {
                DestroyBarrior?.Invoke();
                Vector2 newScale = switchSprite.transform.localScale;
                newScale.x = -.6f;
                switchSprite.transform.localScale = newScale;
            }
        }
    }
}

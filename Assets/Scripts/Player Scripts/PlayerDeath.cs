using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject respawn;
    public Animator anim; 
    private void OnTriggerEnter2D(Collider2D other) { 
        //if you fall off the map, respawn
        if (other.tag == "Respawn") {
            gameObject.transform.position = respawn.transform.position; 
            gameObject.transform.rotation = respawn.transform.rotation; 
        }

        //if you hit spikes, take health damage
        if (other.tag == "Spikes") {
            PlayerDies();
        }
    }

    public void PlayerDies() {
        anim.SetTrigger("isDead"); 
        StartCoroutine(DelayedRestart(anim.GetCurrentAnimatorStateInfo(0).length)); 

    }

    IEnumerator DelayedRestart(float _delay = 0) {
        yield return new WaitForSeconds(_delay);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}

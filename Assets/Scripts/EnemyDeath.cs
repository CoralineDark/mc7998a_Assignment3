using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            anim.SetTrigger("isDead"); 
            StartCoroutine(DelayedRestart(anim.GetCurrentAnimatorStateInfo(0).length));     
        }
    }
    IEnumerator DelayedRestart(float _delay = 0) {
        yield return new WaitForSeconds(_delay);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class EnemyDamage : MonoBehaviour
{

    [SerializeField]
    private int enemyDamage; 
    public static event Action<int> PlayerDamaged; 
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerDamaged?.Invoke(10);
        }
    }
}

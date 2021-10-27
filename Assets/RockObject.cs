using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObject : MonoBehaviour, IPooledObject 
{
    public float upForce = -1f; 
    public float sideForce = .1f; 
    public void OnObjectSpawn() {
        float xForce = UnityEngine.Random.Range(-sideForce, sideForce);
        float yForce = UnityEngine.Random.Range(upForce / 2f, upForce); 

        Vector2 force = new Vector2(xForce, yForce);
        GetComponent<Rigidbody2D>().velocity = force;    
    }
}

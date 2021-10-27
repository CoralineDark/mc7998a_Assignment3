using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    //I changed this to Rocks
    ObjectPooler objectPooler; 

    private void Start() {
        objectPooler = ObjectPooler.Instance; 
    }
    private void FixedUpdate() {
        ObjectPooler.Instance.SpawnFromPool("Rock", transform.position, Quaternion.identity); 
    }
}

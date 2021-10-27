using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarriorObject : MonoBehaviour
{

    private void OnEnable() { 
        Switch.DestroyBarrior += DestroyBarrior;  
    }

    private void OnDisable() {
        Switch.DestroyBarrior -= DestroyBarrior; 
    }
    private void DestroyBarrior() {
        gameObject.SetActive(false);
    }
}

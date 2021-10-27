using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference https://www.youtube.com/watch?v=rn3tCuGM688 
public class AIPatrol : MonoBehaviour
{
    public bool mustPatrol; 
    public Rigidbody2D rb;
    public float walkSpeed; 
    public Transform groundCheckPos; 
    public bool mustTurn; 
    public LayerMask groundLayer; 
    public Collider2D bodyCollider; 
    void Start()
    {
        mustPatrol = true; 
    }

    // Update is called once per frame
    void Update()
    {
       if (mustPatrol) { Patrol();}
    }

    private void FixedUpdate() { 
        if (mustPatrol) {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer); 
        }
    }
    private void Patrol() {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer)) 
            {Flip();} 
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y); 
    }

    private void Flip() { 
        mustPatrol = false; 
        transform.localScale = new Vector2(transform.localScale.x*-1, transform.localScale.y);
        walkSpeed *= -1; 
        mustPatrol = true; 
    }
}

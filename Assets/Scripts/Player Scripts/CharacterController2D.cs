using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rb; 
    private bool speedBoosted; 
    private float speedTimer; 

    [SerializeField]
    private float _movementSpeed;
    private float _jumpForce; 
    public GameObject playerSprite; 

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movementSpeed = 3.0f;
        _jumpForce = 10.0f;
        speedBoosted = false;
        speedTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //move
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * _movementSpeed;

        //flip
        Vector2 characterScale = playerSprite.transform.localScale;
        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -.75f;
        }
        if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = .75f;
        }
        playerSprite.transform.localScale = characterScale;

        //jump=
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rb.velocity.y) < 0.001) {
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        //boost speed 
        if (speedBoosted) {
            speedTimer -= Time.deltaTime; 
        } else if (!speedBoosted) {
            speedBoosted = false; 
            _movementSpeed = 3f; 
        }

        if (speedTimer <= 0) {
        speedBoosted = false;
        _movementSpeed = 3f;
        }
        
    }

    //Getters and Setters 
    public float getMovementSpeed() {
        return _movementSpeed;
    }

    public void setMovementSpeed(float newSpeed) {
        _movementSpeed = newSpeed;
    }

    public float getJumpForce() {
        return _jumpForce;
    }

    public void setJumpForce(float newForce) {
        _jumpForce = newForce;
    }
}

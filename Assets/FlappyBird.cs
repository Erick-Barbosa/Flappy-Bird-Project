using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlappyBird : MonoBehaviour {
    private AudioSource[] sounds;
    Rigidbody2D body;

    [SerializeField] private float jumpPower = 5.0f;
    private bool isJumping = false;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sounds = GetComponentsInChildren<AudioSource>();
    }

    void Update()
    {   
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
            isJumping = true;
        }

        transform.eulerAngles = new Vector3 (0f, 0f, body.velocity.y * 3.0f);
    }
    private void FixedUpdate() {
        if (isJumping) {
            sounds[1].Play();
            body.velocity = new Vector2(0.0f, jumpPower);
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        UIManager.Instance.ScorePoint();
        sounds[0].Play();
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
        UIManager.Instance.SetGameOver();        
    }
}

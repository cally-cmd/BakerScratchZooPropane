using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baker : MonoBehaviour
{

    private Rigidbody2D body;
    public float horizontal;

    //private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool jumping = false;

    public float runSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //animator.SetFloat("horizontal", horizontal);
        if (horizontal < 0) {
            spriteRenderer.flipX = true;
            if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.knifeCollected) {
                body.AddForce(new Vector2(-325, 0));
            }
        } else {
            spriteRenderer.flipX = false;
            if (Input.GetKeyDown(KeyCode.W) && GameManager.Instance.knifeCollected) {
                body.AddForce(new Vector2(325, 0));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && !jumping) {
            print("Space!");
            body.AddForce(new Vector2(0, 325));
            jumping = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && GameManager.Instance.bakingCollected) {
            body.AddForce(new Vector2(0, 650));
        }
    }

    void FixedUpdate() {

        body.velocity = new Vector2(horizontal * runSpeed, body.velocity.y);

    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        jumping = false;
    }
}

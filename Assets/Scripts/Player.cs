using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float Speed = 8f;
    private float Horizontal;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private Animator animator;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Debug.Log(Horizontal);
        this.rb.velocity = new Vector2(Horizontal * Speed,rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));

        if (Input.GetKeyDown(KeyCode.Space)) {
            this.rb.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
        }

        Flip();
        /*if (Input.GetKey(KeyCode.Space)) {
            Debug.Log("A");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("B");
        }*/
    }

    private void Flip()
    {
        if(isFacingRight && Horizontal < 0f || !isFacingRight && Horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

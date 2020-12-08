using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidad = 12f;
    [SerializeField] private float velocidad2 = 12f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D cd;
    [SerializeField] private bool IsGrounded = true;
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Animator an;
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        an.SetBool("IsRuning", false);
        an.SetBool("IsJumping", false);
        if (movement != 0)
        {
            if (movement > 0)
            {
                sp.flipX = false;
                an.SetBool("IsRuning", true);

            }
            else
            {
                sp.flipX = true;
                an.SetBool("IsRuning", true);
            }
            rb.velocity = new Vector2(velocidad * movement, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded==true)
        {
            an.SetBool("IsJumping", true);
            rb.AddForce(new Vector2(0, velocidad2), ForceMode2D.Impulse);
            IsGrounded = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            IsGrounded = true;
        }
        if (collision.collider.tag == "FinMapa")
        {
            rb.transform.position = new Vector2(-2.0f, -2.0f);
        }
    }
}

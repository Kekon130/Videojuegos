﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_Horizontal : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D cd;
    [SerializeField] private CapsuleCollider2D cD;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool IsGrounded = false;
    [SerializeField] private float velocidad = 20f;
    void Update()
    {
        if (IsGrounded == true)
        {
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            IsGrounded = true;
        }
        else if (collision.collider.tag == "Player" && IsGrounded == true)
        {
            IsGrounded = false;
        }
        else if (collision.collider.tag == "Player" && IsGrounded == false)
        {
            IsGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Colider"))
        {
            IsGrounded = false;
        }
    }
}

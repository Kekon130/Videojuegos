using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_behaviour : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D cd;
    public bool player = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = true;
            Destroy(gameObject);
        }
    }
}

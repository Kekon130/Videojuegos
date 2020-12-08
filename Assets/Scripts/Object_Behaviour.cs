using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Behaviour: MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D cd;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "FinMapa")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Player : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D cc;
    [SerializeField] private Animator an;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int vidas = 3;
    [SerializeField] private int coin = 0;
    [SerializeField] private float tiempo = 0.0f;
    [SerializeField] private Contador_Vidas barra;
    [SerializeField] private Contador_Monedas coins;
    [SerializeField] GameObject[] prefab;

    void Start()
    {
        an.SetInteger("Lives", vidas);
    }

    void Update()
    {
        an.SetInteger("Lives", vidas);
        if (vidas == 0)
        {
            tiempo = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        while (vidas == 0)
        {
            tiempo = tiempo + 0.5f;
            if (tiempo == 1000)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.transform.position = new Vector2(-2, -2);
                vidas = 3;
                barra.subirVida(vidas);
                coin = 0;
                coins.reiniciarContador(coin);
                tiempo = 0;
            }
        }
        if (tiempo == 1500 && vidas > 0)
        {
            Instantiate(prefab[Random.Range(0,3)], new Vector3(-Random.Range(-34.2f, 29.1f), -3, 0), Quaternion.identity, null);
            tiempo = 0;
        }
        tiempo++;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            vidas--;
            barra.bajarVida(vidas);

        }
        else if (collision.collider.tag == "Life")
        {
            vidas++;
            barra.subirVida(vidas);
        }
        else if (collision.collider.tag == "FinMapa")
        {
            vidas--;
            barra.bajarVida(vidas);

        }
        else if (collision.collider.tag == "Coin")
        {
            coin++;
            coins.aumentarContador(coin);
        }
    }
}

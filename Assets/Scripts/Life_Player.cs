using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Player : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D cc;
    [SerializeField] private Animator an;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int vidas = 3;
    [SerializeField] private float tiempo = 0.0f;
    [SerializeField] private Contador_Vidas barra;
    [SerializeField] private GameObject prefab;
    void Start()
    {
        an.SetInteger("Lives", vidas);
    }

    // Update is called once per frame
    void Update()
    {
        an.SetInteger("Lives", vidas);
        if (vidas == 0)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (tiempo == 2000 && vidas > 0)
        {
            Instantiate(prefab, new Vector3(-Random.Range(-34.2f, 29.1f), -3, 0), Quaternion.identity, null);
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
        if (collision.collider.tag == "FinMapa")
        {
            vidas--;
            barra.bajarVida(vidas);

        }
    }
}

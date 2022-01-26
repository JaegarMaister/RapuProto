using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Julkiset muuttujat")]
    public float hyppyVoima;
    public bool maassa;
    private Rigidbody2D rb2d;

    [Header("Yksityiset muuttujat")]
    [SerializeField] private Transform maaTarkistus;
    [SerializeField] private LayerMask onkoMaa;
    [SerializeField] private float ympyraSade;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Tarkistetaan onko pelaajahahmo maassa
        maassa = Physics2D.OverlapCircle(maaTarkistus.position, ympyraSade, onkoMaa);

        if (Input.GetButtonDown("Jump") && maassa)
        {
            // Funktio toteuttaa hypyn antamalla voimaa
            rb2d.velocity = new Vector2(rb2d.velocity.x, hyppyVoima);
        }
    }

    //Piirtaa pienen ympyran, jolla tarkistetaan koskettaako hahmo maata
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(maaTarkistus.position, ympyraSade);
    }

}

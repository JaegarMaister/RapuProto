using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapuHyppy : MonoBehaviour
{
    // Muuttujat ovat jatettu vapaaksi, jotta niita voi editorissa muokata

    [Header("Julkiset muuttujat")]
    public float hyppyVoima;
    public bool maassa;
    private Rigidbody2D rb2d;

    [Header("Yksityiset muuttujat")]
    [SerializeField] private Transform maaTarkistus;
    [SerializeField] private LayerMask onkoMaa;
    [SerializeField] private float ympyraSade;
    [SerializeField] private Vector2 vektori;
    [SerializeField] private float laatikkoKulma;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Tarkistetaan onko rapu maassa
        //maassa = Physics2D.OverlapCircle(maaTarkistus.position, ympyraSade, onkoMaa);
        maassa = Physics2D.OverlapBox(maaTarkistus.position, vektori, laatikkoKulma, onkoMaa);

        if (Input.GetButtonDown("Jump") && maassa)
        {
            // Funktio toteuttaa hypyn antamalla voimalla
            rb2d.velocity = new Vector2(rb2d.velocity.x, hyppyVoima);
        }
    }

    // Piirtaa pienen ympyran, jolla tarkistetaan koskettaako rapu maata
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(maaTarkistus.position, ympyraSade);
        Gizmos.DrawCube(maaTarkistus.position, vektori);
    }

}

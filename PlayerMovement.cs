using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // Tarpeellisia animaation ja fysiikan toimimiselle
    private Rigidbody2D rb2d;
    private Animator myAnimator;

    private bool suuntaOikea = false;

    // Muuttujia
    public float speed = 2.0f;
    public float horizMovement;

    // Start is called before the first frame update
    private void Start()
    {
        // Maarittelee gameobjectit, jotka loytyvat pelaajahahmosta
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    // Sen lisaksi kasittelee fysiikalle annetut syotteet
    private void Update()
    {
        horizMovement = Input.GetAxis("Horizontal");
    }

    // Kasittelee fysiikan pyorittamisen
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizMovement * speed, rb2d.velocity.y);
        Flip(horizMovement);
    }

    //Aliohjelma, jolla kaannetaan hahmo
    private void Flip(float h)
    {
        if (h < 0 && suuntaOikea || h > 0 && !suuntaOikea)
        {
            suuntaOikea = !suuntaOikea;

            Vector3 skaala = transform.localScale;
            skaala.x *= -1;
            transform.localScale = skaala;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorDeEnemigo : MonoBehaviour
{
    float speed = 4;
    Vector2 velocidad;
    public bool start = false;
    private bool flip = false;
    public int potenciaDeSaltoDeMario = 20;
    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            //derecha
            velocidad = Vector2.left * speed;
            if (flip)
            {
                velocidad *= -1;
            }
            velocidad.y = GetComponent<Rigidbody2D>().velocity.y;
            GetComponent<Rigidbody2D>().velocity = velocidad;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstaculo") || collision.gameObject.CompareTag("enemigo"))
        {
            flip = !flip;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pies"))
        {
            GameObject.Find("SFX").GetComponent<ControladorDeSonidos>().EjecutarSonido("matarEnemigo");
            start = false;
            GetComponent<Animator>().SetTrigger("morir");
            collision.gameObject.transform.parent.gameObject.GetComponent<MovimientoMario>().Saltar(potenciaDeSaltoDeMario/100);
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    public void Morir()
    {
        Destroy(gameObject);
    }

}

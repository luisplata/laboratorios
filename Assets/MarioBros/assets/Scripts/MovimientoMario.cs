using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMario : MonoBehaviour
{
    float speed = 7;
    float speedJump = 170000;
    bool isJump;
    Vector2 velocidad;
    // Update is called once per frame
    void Update()
    {
        //Controlando el movimiento
        float input = Input.GetAxis("Horizontal");
        //Se esta moviendo
        if (input != 0)
        {
            if(input > 0)
            {
                //derecha
                velocidad = Vector2.right * speed;
                //Colocando la imagen a su orientacion original
                gameObject.transform.Find("30_mario_1").GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                //izquierda
                velocidad = Vector2.left * speed;
                //Colocando la imagen a la orientacion invertida en X
                gameObject.transform.Find("30_mario_1").GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else{
            velocidad = Vector2.zero;
        }
        //Agregando la velocidad a Mario
        //Velocidad de caida
        velocidad.y = GetComponent<Rigidbody2D>().velocity.y;
        //velocidad de desplazamiento
        GetComponent<Rigidbody2D>().velocity = velocidad;
        //Mandamos la velocidad al animador para que anime en caso de que se este movimiendo
        gameObject.transform.Find("30_mario_1").GetComponent<Animator>().SetFloat("velocidad", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        //salto de mario
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !isJump)
        {
            GameObject.Find("SFX").GetComponent<ControladorDeSonidos>().EjecutarSonido("saltar");
            Saltar();
            //Le decimos al animador que ejecute la animacion de salto
            gameObject.transform.Find("30_mario_1").GetComponent<Animator>().SetBool("saltando", true);
            isJump = true;
        }
    }

    public void Saltar(float porcentaje = 1)
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * speedJump * 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("enemigo"))
        {
            //Le decimos al animador que quite la animacion de salto
            gameObject.transform.Find("30_mario_1").GetComponent<Animator>().SetBool("saltando", false);
            isJump = false;
        }
        else
        {
            //detenemos al enemigo
            if (collision.gameObject.GetComponent<ControladorDeEnemigo>())
            {
                collision.gameObject.GetComponent<ControladorDeEnemigo>().start = false;
            }
            GameObject.Find("Musica").GetComponent<AudioSource>().Stop();
            GameObject.Find("SFX").GetComponent<ControladorDeSonidos>().EjecutarSonido("marioMuere");
            gameObject.transform.Find("30_mario_1").GetComponent<Animator>().SetTrigger("morir");
            speed = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cuadricula"))
        {
            GameObject.Find("Musica").GetComponent<AudioSource>().Stop();
            GameObject.Find("SFX").GetComponent<ControladorDeSonidos>().EjecutarSonido("finDelJuego");
            GetComponent<MovimientoMarioPrefabricado>().enabled = true;
            GetComponent<MovimientoMario>().enabled = false;
        }
    }

}

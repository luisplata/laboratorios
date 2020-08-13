using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGenerico : MonoBehaviour
{
    public float speed = 2;
    public float speedJump, direccion;
    private Rigidbody2D rb;
    [SerializeField]
    private float min, max, x,y, deltaTimeLocal, alturamax;
    [SerializeField]
    private bool comenzarContar, ordencreciente, punio, patada, estaEnPiso;
    private void Start()
    {
        min = -1f;
        max = 1f;
        estaEnPiso = true;
        ordencreciente = true;
        rb = GetComponent<Rigidbody2D>();
        deltaTimeLocal = min;
    }
    // Update is called once per frame
    void Update()
    {
        if (!comenzarContar)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                x = 1;
                //derecha
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                x = -1;
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                x = 0;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                GetComponent<Animator>().SetTrigger("saltar");
                estaEnPiso = false;
                comenzarContar = true;
            }
        }


        if (comenzarContar)
        {
            direccion = x;
            deltaTimeLocal += (Time.deltaTime*2);
            //La funcion matematica debe dar la sensacion de suavidad, aun esta tosco
            //cos(x)
            y = Mathf.Cos(deltaTimeLocal) * speedJump;
            //2x^(3)+2
            //y = ((2 * Mathf.Pow(deltaTimeLocal, 3)) + 2) * speedJump;
            if (y > alturamax)
            {
                alturamax = y;
            }
            else
            {
                y *= -1;
            }
            if (deltaTimeLocal >= max)
            {
                ResetObject();
            }
        }
        else
        {
            y = rb.velocity.y;
        }

        rb.velocity = new Vector2(x * speed, y);
        //rb.velocity = new Vector2(x * speed, rb.velocity.y);
        GetComponent<Animator>().SetFloat("velocidad", Mathf.Abs(rb.velocity.x));
    }

    public void ResetObject()
    {
        comenzarContar = false;
        deltaTimeLocal = min;
        y = 0;
        alturamax = -1;
        estaEnPiso = true;
        GetComponent<Animator>().SetTrigger("tocarPiso");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (comenzarContar)
        {
            ResetObject();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (comenzarContar)
        {
            ResetObject();
        }
    }

}

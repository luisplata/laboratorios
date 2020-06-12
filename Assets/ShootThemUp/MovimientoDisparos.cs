using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDisparos : MonoBehaviour
{
    public GameObject disparo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed, speedDisparo;

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && GameObject.FindGameObjectsWithTag("disparo").Length < 2)
        {
            GameObject disparoInstanciado = Instantiate(disparo, transform);
            //le damos velocidad
            disparoInstanciado.GetComponent<Rigidbody2D>().velocity = Vector2.up * speedDisparo;
        }
        float cardinalidad = 0;
        if (Input.GetAxis("Horizontal") != 0)
        {
            cardinalidad = Input.GetAxis("Horizontal") < 0 ? -1 : 1;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(cardinalidad * speed, 0);
    }
}

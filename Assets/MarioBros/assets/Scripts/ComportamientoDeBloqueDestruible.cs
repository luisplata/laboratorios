using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoDeBloqueDestruible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cabeza"))
        {
            GameObject.Find("SFX").GetComponent<ControladorDeSonidos>().EjecutarSonido("romperBloque");
            GetComponent<Animator>().SetTrigger("destruir");
        }
    }

    public void SeTerminoDeDestruir()
    {
        Destroy(gameObject);
    }

}

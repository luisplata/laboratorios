using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorDeEnemigos : MonoBehaviour
{
    public ControladorDeEnemigo enemigo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemigo.start = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDelJuegoMario : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Fin del juego, reiniciamos todo
            collision.gameObject.GetComponent<MovimientoMarioPrefabricado>().speed = 0;
            StartCoroutine(ReloadEscenario());
        }
    }

    IEnumerator ReloadEscenario()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("MarioBross");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeAnimacionesDeMario : MonoBehaviour
{

    public void ReiniciarJuego()
    {
        Debug.Log("Se reinicia el juego");
        SceneManager.LoadScene("MarioBross");
    }
}

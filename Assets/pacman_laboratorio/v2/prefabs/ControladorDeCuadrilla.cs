using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeCuadrilla : MonoBehaviour {
    [SerializeField]
    private bool estaOcupado;
    private void OnTriggerStay2D (Collider2D other) {
        if (!other.gameObject.transform.CompareTag ("cuadricula") && !other.gameObject.transform.CompareTag ("Player")) {
            estaOcupado = true;
        }
    }
    void OnTriggerExit2D (Collider2D other) {
        estaOcupado = false;
    }
    void Update () {
        if (!estaOcupado) {
            gameObject.layer = LayerMask.NameToLayer ("Default");
        }
    }

    public bool EstaOcupado () {
        return estaOcupado;
    }
}
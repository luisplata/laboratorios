using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigonometria : MonoBehaviour
{
    //vamos a mostrar primero resultados
    public float teta;
    //ahora vamos a darle movimiento a l objeto
    public GameObject objeto;

    // Update is called once per frame
    void Update()
    {
        //teta es x and y es el seno
        objeto.transform.position = new Vector2(teta, Mathf.Sin(teta));
        Debug.Log(Mathf.Sin(teta));
        teta += Time.deltaTime;
    }
}

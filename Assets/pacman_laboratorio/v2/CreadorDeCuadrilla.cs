using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDeCuadrilla : MonoBehaviour {
    public GameObject cuadrado;
    public int n, m;
    public float escalaAdecuada, distancia;
    List<GameObject> listaDeCuadrillaCreada = new List<GameObject> ();
    void Start () {
        //cambiamos la escala de la cuadrilla para hacerla mas maneable
        cuadrado.transform.localScale = new Vector3 (escalaAdecuada, escalaAdecuada, 0);
        //tomamos la escala del cuadrado para saber a que otra distancia colocamos cada cuadrilla
        //float distancia = cuadrado.transform.localScale.x;
        //creamos la cuadrilla solamente en el start y hacemos el for para eso
        Vector3 posicionInicial = transform.position;
        for (int i = 1; i <= m; i++) {
            for (int o = 1; o <= n; o++) {
                GameObject instancia = Instantiate(cuadrado, transform.position, transform.rotation);
                instancia.name = i + "_" + o;
                listaDeCuadrillaCreada.Add (instancia);
                Vector3 nuevaPosicion = transform.position + new Vector3 (distancia, 0, 0);
                transform.position = nuevaPosicion;
            }
            posicionInicial = transform.position = posicionInicial - new Vector3 (0, distancia, 0);
        }

        //le colocamos el padre a los objetos creados
        foreach (GameObject item in listaDeCuadrillaCreada) {
            item.transform.SetParent (transform);
        }
    }
}
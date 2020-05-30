using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour {

    private Vector3 direccion;
    List<Vector3> cardinalidad;
    [SerializeField]
    private GameObject target;
    public GameObject objetivoFinal;
    public float speed = 1.0f;

    private bool llegoSuObjetivo;

    //lista de cubos recorridos
    [SerializeField]
    List<GameObject> listaDeCubosRecorridos;
    void Start () {
        listaDeCubosRecorridos = new List<GameObject> ();
        cardinalidad = new List<Vector3> ();
        cardinalidad.Add (Vector3.up);
        cardinalidad.Add (Vector3.down);
        cardinalidad.Add (Vector3.left);
        cardinalidad.Add (Vector3.right);
        direccion = Vector3.up;
        target = gameObject;
    }

    float distancia = 1;
    // Update is called once per frame
    //GetComponent<Rigidbody2D> ().velocity = direccion;
    void Update () {
        Vector3 masCerca = new Vector3 (1000, 0, 0);
        if (llegoSuObjetivo) {
            List<Vector3> cardinalidades = cardinalidad.FindAll (dir => Physics2D.Raycast (transform.position, dir, distancia).collider != null);
            cardinalidades = cardinalidades.FindAll (dir1 => Physics2D.Raycast (transform.position, dir1, distancia).transform.CompareTag ("cuadricula"));
            cardinalidades = cardinalidades.FindAll (dir2 => !Physics2D.Raycast (transform.position, dir2, distancia).transform.GetComponent<ControladorDeCuadrilla> ().EstaOcupado ());
            foreach (Vector3 item in cardinalidades) {
                Debug.DrawRay (transform.position, (item), Color.yellow);
                Vector3 items = objetivoFinal.transform.position - Physics2D.Raycast (transform.position, item, distancia).transform.position;
                Vector3 itemsActual = objetivoFinal.transform.position - target.transform.position;
                if (items.magnitude < itemsActual.magnitude) {
                    masCerca = item;
                } else if (itemsActual.magnitude < masCerca.magnitude) {
                    //de los tantos que pasaron cual es el menor
                    masCerca = item;
                }
            }
            //cardinalidades.Sort ((a, b) => a.CompareTo (b));
            RaycastHit2D hit = Physics2D.Raycast (transform.position, masCerca, distancia);
            if (hit.collider != null) {
                //quitamos los que no queremos
                if (!hit.transform.CompareTag ("Finish")) {
                    //tenemos que ignorar los que ya estan ocupados
                    if (!hit.collider.gameObject.GetComponent<ControladorDeCuadrilla> ().EstaOcupado () && !listaDeCubosRecorridos.Contains (hit.collider.gameObject)) {
                        target = hit.collider.gameObject;
                        listaDeCubosRecorridos.Add (target);
                    } else {
                        hit.transform.gameObject.layer = LayerMask.NameToLayer ("Ignore Raycast");
                    }
                }
            } else {
                target = gameObject;
            }
            //buscamos el siguiente objetivo para moverse
        }
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
        llegoSuObjetivo = transform.position == target.transform.position;
    }
}
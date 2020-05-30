using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeMovimientoPacman : MonoBehaviour
{
    public float speed;
    /* blink va al centro (0,0)
     * pinky adelante (0,1)
     * inky va a la derecha (1,0)
     * clyde va a la izquierda (-1,0)
     */
    public GameObject blink, pinky, inky, clyde;

    // Update is called once per frame
    void Update()
    {
        Vector2 cardinalidad = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Debug.Log(cardinalidad);
        GetComponent<Rigidbody2D>().velocity =  cardinalidad* speed;
        //acomodamos los objetos que persiguen los fantasmas para que se coloquen en la cardinalidad que corresponde
        //primero miramos quien es mas fuerte x o y
        if(Mathf.Abs( cardinalidad.x) > Mathf.Abs(cardinalidad.y))
        {
            //va por el eje x ahora buscamos para donde va
            if(cardinalidad.x > 0)
            {
                //va para la derecha
                ColocandoFantasmas("derecha");
            }
            else
            {
                //va para la izquierda
                ColocandoFantasmas("izquierda");
            }
        }
        else
        {
            //va por el eje y ahora buscamos para donde va
            if (cardinalidad.y > 0)
            {
                //va para la arriba
                ColocandoFantasmas("arriba");
            }
            else
            {
                //va para la abajo
                ColocandoFantasmas("abajo");
            }
        }
    }

    private void ColocandoFantasmas(string cardinalidad)
    {
        //vamos a usar la escala de pacman para posicionarlos
        float distancia = gameObject.transform.localScale.x * 4;
        switch (cardinalidad)
        {
            case "arriba":
                /* pinky: 0,1
                 * inky: 1,0
                 * clyde: -1,0
                 * blink: 0,0
                 */
                blink.transform.position = (Vector2)transform.position+ new Vector2(0, 0);
                pinky.transform.position = (Vector2)transform.position + new Vector2(0, distancia);
                inky.transform.position = (Vector2)transform.position + new Vector2(distancia, 0);
                clyde.transform.position = (Vector2)transform.position + new Vector2(-distancia, 0);
                break;
            case "abajo":
                /* pinky: 0,-1
                 * inky: -1,0
                 * clyde: 1,0
                 * blink: 0,0
                 */
                pinky.transform.position = (Vector2)transform.position + new Vector2(0, -distancia);
                inky.transform.position = (Vector2)transform.position + new Vector2(-distancia, 0);
                clyde.transform.position = (Vector2)transform.position + new Vector2(distancia, 0);
                blink.transform.position = (Vector2)transform.position + new Vector2(0, 0);
                break;
            case "derecha":
                /* pinky: 1,0
                 * inky: 0,-1
                 * clyde: 0,1
                 * blink: 0,0
                 */
                pinky.transform.position = (Vector2)transform.position + new Vector2(distancia, 0);
                inky.transform.position = (Vector2)transform.position + new Vector2(-distancia, 0);
                clyde.transform.position = (Vector2)transform.position + new Vector2(distancia, 0);
                blink.transform.position = (Vector2)transform.position + new Vector2(0, 0);
                break;
            case "izquierda":
                /* pinky: -1,0
                 * inky: 0,1
                 * clyde: 0,-1
                 * blink: 0,0
                 */
                pinky.transform.position = (Vector2)transform.position + new Vector2(-distancia, 0);
                inky.transform.position = (Vector2)transform.position + new Vector2(0, distancia);
                clyde.transform.position = (Vector2)transform.position + new Vector2(0, -distancia);
                blink.transform.position = (Vector2)transform.position + new Vector2(0, 0);
                break;
        }
    }
}

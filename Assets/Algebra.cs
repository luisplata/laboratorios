using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Algebra : MonoBehaviour
{
    // Start is called before the first frame update
    //vamos a mover el objeto a la velocidad de la operacion
    float x;
    public int valorX;
    public TextMeshProUGUI texto;
    void Start()
    {
        //operacion 3x+4x^2
        
    }

    // Update is called once per frame
    void Update()
    {
        x = 3 * valorX + 4 * valorX ^ 2;
        texto.text = x.ToString();
        GetComponent<Rigidbody2D>().velocity = new Vector2(x,0);
    }
}

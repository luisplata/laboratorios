using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeMovimientoGenerico : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }
    public float speed;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal"), 0) * speed);
    }
}

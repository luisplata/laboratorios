using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDeMovimiento : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis(" )
    }

    public float GetSpeed
    {
        get { return speed; }
        set { speed = value; }
    }
    public Rigidbody2D Rigidbody2D => rb;
}

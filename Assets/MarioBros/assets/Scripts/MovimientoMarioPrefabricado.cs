using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMarioPrefabricado : MonoBehaviour
{
    public float speed = 7;
    Vector2 velocidad;
    // Update is called once per frame
    void Update()
    {
        //derecha
        velocidad = Vector2.right * speed;
        gameObject.transform.Find("30_mario_1").GetComponent<SpriteRenderer>().flipX = false;
        GetComponent<Rigidbody2D>().velocity = velocidad;
        gameObject.transform.Find("30_mario_1").GetComponent<Animator>().SetFloat("velocidad", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inicio"))
        {
            gameObject.AddComponent(typeof(MovimientoMario));
            GetComponent<MovimientoMarioPrefabricado>().enabled = false;
            collision.gameObject.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDeSprite : MonoBehaviour
{
    public float velocidad;
    [SerializeField]
    private bool punio, patada;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.Joystick1Button3)) && !punio && !patada)
        {
            patada = true;
            GetComponent<Animator>().SetBool("patada", true);
        }

        if ((Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && !punio && !patada)
        {
            punio = true;
            GetComponent<Animator>().SetBool("punio", punio);
        }
        //mandando al animator la velocidad
        GetComponent<Animator>().SetFloat("velocidad", velocidad);
    }

    public void FinalDePatada()
    {
        patada = false;
        GetComponent<Animator>().SetBool("patada", patada);
    }


    public void FinalDePunio()
    {
        punio = false;
        GetComponent<Animator>().SetBool("punio", punio);
    }
}

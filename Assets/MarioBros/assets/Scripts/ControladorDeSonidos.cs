using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonidos : MonoBehaviour
{
    public List<AudioClip> libreriaDeSonidos;
    public AudioSource source;

    public void EjecutarSonido(string nombre)
    {
        foreach(AudioClip audio in libreriaDeSonidos)
        {
            if(audio.name == nombre)
            {
                source.PlayOneShot(audio);
            }
        }
    }
}

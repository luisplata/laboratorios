using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractuable : MonoBehaviour
{
    [TextArea]
    [Tooltip("A string using the TextArea attribute")]
    public string dialogoBueno, dialogoMalo, dialogoFinal;
    public List<ObjetoInteractuable> aristas;
    private TeoriaDeGrafos padre;
    private void Start()
    {
        padre = GameObject.Find("TeoriaDeGrafos").GetComponent<TeoriaDeGrafos>();
    }

    //preguntar si es el objeto final
    //si no mostar dialogos
    public void GenerarDialogosDeAristas()
    {
        string[] dialogos = new string[aristas.Count];
        if (padre.verticeFinal.Equals(this))
        {
            int last = dialogos.Length - 1;
            dialogos[last] = dialogoFinal;
        }
        else
        {
            foreach (ObjetoInteractuable intera in aristas)
            {
                int last = dialogos.Length - 1;
                //dialogos[last] = intera.;
            }
        }
    }
}

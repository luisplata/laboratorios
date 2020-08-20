using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoInteractuable : MonoBehaviour
{
    [TextArea]
    [Tooltip("A string using the TextArea attribute")]
    public string dialogoBueno, dialogoMalo, dialogoFinal;
    public List<ObjetoInteractuable> aristas;
    private TeoriaDeGrafos padre;
    private Button boton;
    public int distancia;
    public bool visitado = false;
    private void Start()
    {
        padre = GameObject.Find("TeoriaDeGrafos").GetComponent<TeoriaDeGrafos>();
        //gameObject.AddComponent<Button>();
        //GetComponent<Button>().onClick.AddListener(delegate { EventoDeClickAgregado(); });
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

    public void EventoDeClickAgregado()
    {
        if(padre.verticeFinal == this)
        {
            Debug.Log(this.dialogoFinal);
            return;
        }
        //Debug.Log("Le Diste click y soy hecho a punta de codigo");
        //ahora vamos a ejecutar la funcion recursiva para retornar los valores
        string[] resultado = padre.DialogosDeEsteObjeto(this);
        foreach(string dialogo in resultado)
        {
            Debug.Log(dialogo);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeoriaDeGrafos : MonoBehaviour
{
    [Header("Vertice Final")]
    [ContextMenuItem("Saca de los vertices actuales uno al azar", "GenerarVerticeFinal")]
    public ObjetoInteractuable verticeFinal;
    public List<ObjetoInteractuable> vertices;
    private List<ObjetoInteractuable> verticesVisitados;
    [Header("Distancias de los vertices")]
    [ContextMenuItem("Ejecutara una funcion recursiva para crear las distancias entre los verices", "GenerarMapaDeDialogosDelGrafo")]
    public ObjetoInteractuable distanciaDesdeAqui;
    private Dictionary<ObjetoInteractuable, int> distanciasPorVertice;
    [SerializeField]
    private int distanciaMaxima;
    
    //Generamos el verice final a partir de los vertices seleccionados

    public void GenerarVerticeFinal()
    {
        //numero random
        int random = UnityEngine.Random.Range(0, vertices.Count);
        verticeFinal = vertices[random];
    }

    public void GenerarMapaDeDialogosDelGrafo()
    {
        /*if(distanciaDesdeAqui == null)
        {
            throw new Exception("No a sido declarado el inicio");
        }

        distanciasPorVertice = new Dictionary<ObjetoInteractuable, int>();
        foreach (ObjetoInteractuable verticeIndivi in distanciaDesdeAqui.aristas)
        {
            verticesVisitados = new List<ObjetoInteractuable>();
            verticesVisitados.Add(distanciaDesdeAqui);
            int distancia = 1;
            distanciaMaxima = 0;
            //setear las distancias ya recorrifas
            foreach (ObjetoInteractuable ob in vertices)
            {
                ob.distancia = 0;
            }
            distancia = FuncionRecursivaParaEncontrarFinal(distancia, verticeIndivi);
            //Debug.Log(">>>>>>>Distancia " + distancia);
            distanciasPorVertice[verticeIndivi] = distancia;
        }
        */
        //ImprimirCasos(distanciasPorVertice);
        
    }

    public string[] DialogosDeEsteObjeto(ObjetoInteractuable origen)
    {
        foreach(ObjetoInteractuable o in origen.aristas)
        {
            //reiniciar el estado vistado a todos
            foreach(GameObject oo in GameObject.FindGameObjectsWithTag("inicio"))
            {
                oo.GetComponent<ObjetoInteractuable>().visitado = false;
                oo.GetComponent<ObjetoInteractuable>().distancia = 0;
            }
            BFS(o);
        }
        return new string[] { "" };
        /*
        distanciasPorVertice = new Dictionary<ObjetoInteractuable, int>();
        string[] resultado = new string[origen.aristas.Count];
        int i = 0;
        foreach (ObjetoInteractuable verticeIndivi in origen.aristas)
        {
            verticesVisitados = new List<ObjetoInteractuable>();
            verticesVisitados.Add(distanciaDesdeAqui);
            int distancia = 1;
            distanciaMaxima = 0;
            //setear las distancias ya recorrifas
            foreach (ObjetoInteractuable ob in vertices)
            {
                ob.distancia = 0;
            }
            distancia = FuncionRecursivaParaEncontrarFinal(distancia, verticeIndivi);
            distanciasPorVertice[verticeIndivi] = distancia;
            i++;
        }

        //debemos organizarlos por orden de distancia
        var query = from pair in distanciasPorVertice orderby pair.Value ascending select pair;
        int o = 0;//es la variable donde vamos a guardar la distancia mas corta para ver si la tomamos de nuevo...
        i = 0;
        foreach (KeyValuePair<ObjetoInteractuable, int> r in query)
        {
            if(i == 0 || r.Value <= o)
            {
                resultado[i] = r.Key.dialogoBueno;
                o = r.Value;
            }
            else
            {
                resultado[i] = r.Key.dialogoMalo;
            }
            //Debug.Log(r.Key.gameObject.name+" indice "+i+" distancia "+r.Value);
            i++;
        }
        return resultado;*/
    }


    public void ImprimirCasos(Dictionary<ObjetoInteractuable, int> listado)
    {
        foreach (KeyValuePair<ObjetoInteractuable, int> result in listado)
        {
            //Debug.Log(string.Format("Objeto-{0}:Distancia-{1}", result.Key.gameObject.name, result.Value));
        }
    }

    public int FuncionRecursivaParaEncontrarFinal(int distancia, ObjetoInteractuable verticeIndividual)
    {
        if (verticeIndividual.Equals(verticeFinal))
        {
            if(distancia < distanciaMaxima)
            {
                distanciaMaxima = distancia;
            }
            else
            {
                //Debug.LogWarning(">>>>>> esporque es el final");
                return distancia;
            }
        }

        if (verticesVisitados.Contains(verticeIndividual) && verticeIndividual.distancia < distancia)
        {
            //Debug.LogWarning("Es porque ya a sido visitado "+ verticeIndividual.gameObject.name +" pero distancia recorrida hasta el fue de: "+verticeIndividual.distancia+" y la recorrida hsata ahora es de "+distancia );
            return distancia;
        }
        else
        {
            verticesVisitados.Add(verticeIndividual);
            verticeIndividual.distancia = distancia;
            ////Todo esta bien
            distancia++;
            foreach (ObjetoInteractuable arista in verticeIndividual.aristas)
            {
                //Debug.LogWarning("El objeto "+verticeIndividual.gameObject.name+" visita a: " + arista.gameObject.name + " distancia hasta aqui es: " + distancia);
                distancia = FuncionRecursivaParaEncontrarFinal(distancia, arista);
            }
            return distancia;
        }
        
    }


    public void BFS(ObjetoInteractuable origen)
    {
        Queue<ObjetoInteractuable> cola = new Queue<ObjetoInteractuable>();
        cola.Enqueue(origen);
        origen.visitado = true;
        int i = 0;
        while (cola.Count > 0)
        {
            ObjetoInteractuable v = cola.Dequeue();
            //si es el final return
            if (v == verticeFinal)
            {
                break;
            }
            i++;
            foreach (ObjetoInteractuable w in v.aristas)
            {
                Debug.Log("origen " + v.name + " distancia hasta ahora " + i + " destino " + w.name + " distancia del destino " + w.distancia + " fue visitado? " + w.visitado);
                if (!w.visitado)
                {
                    w.visitado = true;
                    w.distancia = i;
                    cola.Enqueue(w);
                }
                else if (w.distancia < i && w == verticeFinal)
                {
                    i = w.distancia;
                }
                else
                {
                    break;
                }
            }
        }
        Debug.Log("i " + i);
    }

}

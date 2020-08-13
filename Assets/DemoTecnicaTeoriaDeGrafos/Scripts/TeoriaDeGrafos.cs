using System;
using System.Collections;
using System.Collections.Generic;
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
    
    //Generamos el verice final a partir de los vertices seleccionados

    public void GenerarVerticeFinal()
    {
        //numero random
        int random = UnityEngine.Random.Range(0, vertices.Count);
        verticeFinal = vertices[random];
    }

    public void GenerarMapaDeDialogosDelGrafo()
    {
        if(distanciaDesdeAqui == null)
        {
            throw new Exception("No a sido declarado el inicio");
        }

        distanciasPorVertice = new Dictionary<ObjetoInteractuable, int>();
        foreach (ObjetoInteractuable verticeIndivi in distanciaDesdeAqui.aristas)
        {
            verticesVisitados = new List<ObjetoInteractuable>();
            verticesVisitados.Add(distanciaDesdeAqui);
            int distancia = 0;
            Debug.Log(">>>>>>>Distancia " + distancia);
            distancia = FuncionRecursivaParaEncontrarFinal(distancia, verticeIndivi);
            distanciasPorVertice[verticeIndivi] = distancia;
        }
        ImprimirCasos(distanciasPorVertice);
    }


    public void ImprimirCasos(Dictionary<ObjetoInteractuable, int> listado)
    {
        foreach (KeyValuePair<ObjetoInteractuable, int> result in listado)
        {
            Debug.Log(string.Format("Objeto-{0}:Distancia-{1}", result.Key.gameObject.name, result.Value));
        }
    }

    public int FuncionRecursivaParaEncontrarFinal(int distancia, ObjetoInteractuable verticeIndividual)
    {
        Debug.LogWarning("Objeto visitado es: " + verticeIndividual.gameObject.name + " distancia hasta aqui es: " + distancia);
        if (verticeIndividual.Equals(verticeFinal))
        {
            Debug.LogWarning(">>>>>> esporque es el final");
            return distancia;
        }else if (verticesVisitados.Contains(verticeIndividual))
        {
            Debug.LogWarning(">>>>>> esporque ya a sido visitado");
            return distancia;
        }
        else
        {
            verticesVisitados.Add(verticeIndividual);
            ////Todo esta bien

            foreach (ObjetoInteractuable arista in verticeIndividual.aristas)
            {
                distancia++;
                FuncionRecursivaParaEncontrarFinal(distancia, arista);
            }
            return distancia;
        }
        
    }
    
}

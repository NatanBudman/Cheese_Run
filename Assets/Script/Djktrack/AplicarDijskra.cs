using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarDijskra : MonoBehaviour
{
    [SerializeField] private int[] origen;

    [SerializeField] private int[] end;
    
    [SerializeField] private  int[] vertices;

    public static GameObject Player;

    [SerializeField] private Nodo[] nodos;
    
    GrafoMA grafoEst = new GrafoMA();

    private void Awake()
    {
        nodos = new Nodo[GameObject.FindObjectsOfType<Nodo>().Length];

        for (int i = 0; i < nodos.Length; i++)
        {
            nodos[i] = GameObject.FindObjectsOfType<Nodo>()[i];
        }
    }

    private void Start()
    {
            Player = GameObject.FindGameObjectWithTag("PlayerDij");
            
           
            ConjuntoLD conjuntoTa = new ConjuntoLD();
            // inicializo TDA
            grafoEst.InicializarGrafo();

            // vector de vértices
            // agrego los vértices
            for (int i = 0; i < vertices.Length; i++)
            {
                grafoEst.AgregarVertice(vertices[i]);
            }
            
            // agrego las aristas
            for (int i = 0; i < nodos.Length; i++)
            {
                conjuntoTa.Agregar(nodos[i], i);
                grafoEst.AgregarNodo(nodos[i]);
            }

            for (int i = 0; i < origen.Length; i++)
            {
                grafoEst.AgregarArista(origen[i], end[i]);
            }
            for (int i = 0; i < grafoEst.cantNodos; i++)
            {
                for (int j = 0; j < grafoEst.cantNodos; j++)
                {
                    if (grafoEst.MAdy[i, j] != 0)
                    {
                        // obtengo la etiqueta del nodo origen, que está en las filas (i)
                        int nodoIni = grafoEst.Etiqs[i];
                        // obtengo la etiqueta del nodo destino, que está en las columnas (j)
                        int nodoFin = grafoEst.Etiqs[j];
                        
                    }
                }
            }

            // al algoritmo le paso el TDA_Grafo estático con los datos cargados y el vértice origen
            AlgDijkstra.Dijkstra(grafoEst, 1);
            
        }

    private int j = 0;
    private void Update()
    {
        if (j < AlgDijkstra.recorridoNodos.Length )
        {
            if (Player.transform.position != AlgDijkstra.recorridoNodos[j].transform.position)
            {
                if (Player.transform.position != grafoEst.nodos[end[0]].transform.position )
                {
                    Player.transform.position = Vector2.MoveTowards(Player.transform.position,
                                        AlgDijkstra.recorridoNodos[j].transform.position, 4 * Time.deltaTime);
                                   Debug.Log(AlgDijkstra.recorridoNodos[j]);
                }
                
            }else
            {
                j++;
            }
            
        }
        
        
    }
}
        

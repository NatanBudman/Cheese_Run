using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AplicarDijskra : MonoBehaviour
{
    public DijstraNatan DijstraNatan;
    public int[] origen;

    public int[] end;
    
    public  int[] vertices;

    public static GameObject Player;

    public Nodo[] nodos;
    
    GrafoMA grafoEst = new GrafoMA();

    private void Awake()
    {
        /*
        nodos = new Nodo[GameObject.FindObjectsOfType<Nodo>().Length];

        for (int i = 0; i < nodos.Length; i++)
        {
            nodos[i] = GameObject.FindObjectsOfType<Nodo>()[i];
        }
        */
   
        
        DijstraNatan.InicializarDijskar();
    }

    private void Start()
    {
        
            var random = UnityEngine.Random.Range(1,nodos.Length);
            nodos[random].transform.GetChild(0).gameObject.SetActive(true);
            end[0] = random;
        
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
            
            DijstraNatan.Dijskra(grafoEst,nodos[origen[0]],nodos[end[0]]);
        }

    private int j = 0;
    private void Update()
    {
        
        if (j < DijstraNatan.NodosRecorrer.Length)
        {
            if (Player.transform.position != nodos[DijstraNatan.NodosRecorrer[j]].transform.position)
            {
                if (Player.transform.position != grafoEst.nodos[end[0]].transform.position )
                {
                    Player.transform.position = Vector2.MoveTowards(Player.transform.position,
                        nodos[DijstraNatan.NodosRecorrer[j]].transform.position, 4 * Time.deltaTime);
                }
                
            }else
            {
                j++;
            }
            
        }
        
        
    }
}
        

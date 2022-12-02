using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class DijstraNatan : MonoBehaviour
{
    public AplicarDijskra AplicarDijskra;
    public int[] NodosRecorrer;
    public float DistamciaMinNodos;
    private int indexRecorrerNodos;
    private int lastNodo;
    private Nodo origen;
    private Nodo target;
    private Nodo sig;
    
    
    public void InicializarDijskar()
    {
        NodosRecorrer = new int[100];
    }



    public void RecorridoArmado( Nodo end)
    {
        Nodo[,] AdyNodos = new Nodo[AplicarDijskra.nodos.Length,100];
        
        
        // busco nodos adyacentes
        if (NodosRecorrer[indexRecorrerNodos] != target.info)
        {
            for (int nodo = 0; nodo <AplicarDijskra.nodos.Length; nodo++)
            {
                for (int nodoAy = 0; nodoAy < AplicarDijskra.nodos.Length; nodoAy++)
                {
                    if (Vector2.Distance(AplicarDijskra.nodos[nodoAy].transform.position, origen.transform.position) <
                        DistamciaMinNodos)
                    {
                        AdyNodos[AplicarDijskra.nodos[nodo].info, AplicarDijskra.nodos[nodoAy].info] = AplicarDijskra.nodos[nodoAy] ;
                        Debug.Log(nodo + "," + nodoAy + "=" + AdyNodos[nodo,nodoAy].ToString());
                    }  else
                    {
                        AdyNodos[AplicarDijskra.nodos[nodo].info, AplicarDijskra.nodos[nodoAy].info] = null ;
                    }
                   


                }
            }


            // busco el nodo adyacente mas cercano al target
            //filtro los nodos lejanos al target
                for (int j = 0; j < AplicarDijskra.nodos.Length; j++)
                {
                    // dist entre el nodo actual con el target
                    float Nodosdist = Vector2.Distance(origen.transform.position, end.transform.position);
                    
                  //  Debug.Log(AdyNodos[AplicarDijskra.nodos[origen.info].info,j]);
                    if (AdyNodos[AplicarDijskra.nodos[origen.info].info,j] != null)
                    {
                        if (Vector2.Distance(AdyNodos[AplicarDijskra.nodos[origen.info].info,j].gameObject.transform.position,
                                                                         target.transform.position) < Nodosdist)
                        {
                            sig = AdyNodos[ AplicarDijskra.nodos[origen.info].info,j];
                                                                     
                            if (Vector2.Distance(sig.transform.position, target.transform.position) > 
                                                                         Vector2.Distance(AdyNodos[AplicarDijskra.nodos[origen.info].info,j].gameObject.transform.position,
                                                                             target.transform.position))
                            {
                                sig = AdyNodos[ AplicarDijskra.nodos[origen.info].info,j];
                                Debug.Log("entre");

                            }
                            
                        }
                        
                    }
                    if (j == AplicarDijskra.nodos.Length - 1)
                    {
                        NodosRecorrer[indexRecorrerNodos] = sig.info;
                        origen = sig;
                        Debug.Log(origen);

                        if (NodosRecorrer[indexRecorrerNodos] == target.info)
                        {
                            Debug.Log("entreeeee");
                            break;
                        }
                        indexRecorrerNodos++;
                        j = 0;
                        

                    }    
                   
                }
             
            
        }
    }

    public void Dijskra(GrafoMA grafoMa, Nodo origen , Nodo target)
        {
            this.origen = origen;
            this.target = target;
            sig = origen;
            while (NodosRecorrer[indexRecorrerNodos] != target.info)
            {
                RecorridoArmado(target);
            }
                
            
        }
}

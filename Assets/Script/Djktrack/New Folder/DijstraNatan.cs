using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
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
    private Nodo[,] AdyNodos;

    public bool isAutoRoute = true;
    public bool isAutoFindAdyNodos = true;
    public bool isIgnoreWalls = true;
    
    public void InicializarDijskar()
    {
        if (isAutoRoute)
        {
            NodosRecorrer = new int[100];
        }

        
        AdyNodos = new Nodo[AplicarDijskra.nodos.Length,100];
    }

    public void LinkNodes()
    {
          if (isAutoFindAdyNodos)
          {
              // busco nodos adyacentes
            
              for (int nodo = 0; nodo <AplicarDijskra.nodos.Length; nodo++)
              {
                  for (int nodoAy = 0; nodoAy < AplicarDijskra.nodos.Length; nodoAy++)
                  {
                      if (Vector2.Distance(AplicarDijskra.nodos[nodo].transform.position,AplicarDijskra.nodos[nodoAy].transform.position) <
                          DistamciaMinNodos)
                      {
                          if (!isIgnoreWalls)
                          {
                                 
                              Vector2 direction = AplicarDijskra.nodos[nodo].transform.position - AplicarDijskra.nodos[nodoAy].transform.position 
                                  ;
                              RaycastHit2D hit = Physics2D.Raycast(AplicarDijskra.nodos[nodo].transform.position,direction,DistamciaMinNodos,LayerMask.GetMask("Default"));
                                 
                              if (!hit.collider.gameObject.CompareTag("wall"))
                              {
                                  AdyNodos[AplicarDijskra.nodos[nodo].info, AplicarDijskra.nodos[nodoAy].info] = AplicarDijskra.nodos[nodoAy] ;
                                  Debug.DrawRay(AplicarDijskra.nodos[nodo].transform.position,direction,Color.red);

                              }
                              else
                              {
                                  Debug.Log("hay pared");
                              }
                                


                          }
                          else
                          {
                              AdyNodos[AplicarDijskra.nodos[nodo].info, AplicarDijskra.nodos[nodoAy].info] = AplicarDijskra.nodos[nodoAy] ;
                              // Debug.Log(nodo + "," + nodoAy + "=" + AdyNodos[nodo,nodoAy].ToString());
                          }
                             

                             
                      }  else
                      {
                          AdyNodos[AplicarDijskra.nodos[nodo].info, AplicarDijskra.nodos[nodoAy].info] = null ;
                      }
                               
            
            
                  }
                     
              }
                 
             
          } 
    }

    public void RecorridoArmado( Nodo end)
    {
        
        if (isAutoRoute)
        {
            // busco el nodo adyacente mas cercano al target
            //filtro los nodos lejanos al target
            for (int j = 0; j < AplicarDijskra.nodos.Length; j++)
            {
                // dist entre el nodo actual con el target
                float Nodosdist = Vector2.Distance(origen.transform.position, end.transform.position);
                                
                //  Debug.Log(AdyNodos[AplicarDijskra.nodos[origen.info].info,j]);
                if (AdyNodos[origen.info,j] != null && AdyNodos[origen.info,j] != target)
                {
                    if (Vector2.Distance(sig.transform.position, target.transform.position) > 
                        Vector2.Distance(AdyNodos[origen.info,j].transform.position,
                            target.transform.position))
                    {
                        if (Vector2.Distance(AdyNodos[origen.info,j].transform.position,
                                                    target.transform.position) < Nodosdist)
                        {
                            sig = AdyNodos[origen.info,j];
                        }
                    }
                    

                    if (AdyNodos[origen.info,j + 1] != null)
                    {
                         if (Vector2.Distance(sig.transform.position, target.transform.position) > 
                                                Vector2.Distance(AdyNodos[origen.info,j + 1].transform.position,
                                                    target.transform.position))
                         {
                             sig = AdyNodos[origen.info, j + 1];
                         }    
                    }  
                     
                }else if (AdyNodos[origen.info,j] == target)
                {
                    sig = AdyNodos[origen.info,j];
                }

                   
                if (j >= AplicarDijskra.nodos.Length - 1)
                {
                    if (sig.info != origen.info)
                    {
                        NodosRecorrer[indexRecorrerNodos] = sig.info;
                        origen = sig;
                        Debug.Log(origen);

                    }
                        
                                 
                    if (origen.info == target.info)
                    {
                        indexRecorrerNodos = 0;
                        break;
                    }
                         
                         
                    if (origen.info != target.info )
                    {
                        indexRecorrerNodos++;
                        j = 0;
                    }
                   
                         
                }    
                               
            }
        }
            
             
            
       
    }

    public void Dijskra(GrafoMA grafoMa, Nodo origen , Nodo target)
    {
            this.origen = origen;
            this.target = target;
            sig = origen;
          
            RecorridoArmado(target);
    }
}

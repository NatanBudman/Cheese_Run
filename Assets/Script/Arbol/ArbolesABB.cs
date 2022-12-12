using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace ABB_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arboles Binarios de Búsqueda
            Console.WriteLine("Programa Iniciado\n");

            // creo un TDA ABB
            ABB arbol = new ABB();

            int[] vectorEnteros = { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 };

            Stopwatch stw = new Stopwatch();

            // agrego los mismos elementos del vector al arbol
            for (int i = 0; i < vectorEnteros.Length; i++)
            {
                arbol.AgregarElem(vectorEnteros[i]);
            }

            stw.Start();
            Console.WriteLine("\nEl mayor es: " + arbol.mayor(arbol).ToString());
            stw.Stop();
            Console.WriteLine("Time elapsed: {0}", stw.Elapsed.ToString("hh\\:mm\\:ss\\.ffff"));
            Console.WriteLine("Ticks elapsed: {0}", stw.ElapsedTicks.ToString());

            stw.Restart();
            Console.WriteLine("\nEl menor es: " + arbol.menor(arbol).ToString());
            stw.Stop();
            Console.WriteLine("Time elapsed: {0}", stw.Elapsed.ToString("hh\\:mm\\:ss\\.ffff"));
            Console.WriteLine("Ticks elapsed: {0}", stw.ElapsedTicks.ToString());

            Console.ReadKey();
        }
    }

    public interface ABBTDA
    {
        int Raiz();
        ABBTDA HijoIzq();
        ABBTDA HijoDer();
        bool ArbolVacio();
        void InicializarArbol();
        void AgregarElem(int x);
        void EliminarElem(int x);
    }

    public class NodoABB
    {
        // datos a almacenar, en este caso un entero
        public int info;
        // referencia los nodos izquiero y derecho
        public ABBTDA hijoIzq;
        public ABBTDA hijoDer;
    }

    public class ABB : ABBTDA
    {
        NodoABB raiz;

        public int Raiz()
        {
            return raiz.info;
        }

        public bool ArbolVacio()
        {
            return (raiz == null);
        }

        public void InicializarArbol()
        {
            raiz = null;
        }

        public ABBTDA HijoDer()
        {
            return raiz.hijoDer;
        }

        public ABBTDA HijoIzq()
        {
            return raiz.hijoIzq;
        }

        public void AgregarElem(int x)
        {
            if(raiz == null)
            {
                raiz = new NodoABB();
                raiz.info = x;
                raiz.hijoIzq = new ABB();
                raiz.hijoIzq.InicializarArbol();
                raiz.hijoDer = new ABB();
                raiz.hijoDer.InicializarArbol();
            }
            else if (raiz.info > x)
            {
                raiz.hijoIzq.AgregarElem(x);
            }
            else if (raiz.info < x)
            {
                raiz.hijoDer.AgregarElem(x);
            }
        }

        public void EliminarElem(int x)
        {
            if (raiz != null)
            {
                if (raiz.info == x && raiz.hijoIzq.ArbolVacio() && raiz.hijoDer.ArbolVacio())
                {
                    raiz = null;
                }
                else if (raiz.info == x && !raiz.hijoIzq.ArbolVacio())
                {
                    raiz.info = this.mayor(raiz.hijoIzq);
                    raiz.hijoIzq.EliminarElem(raiz.info);
                }
                else if (raiz.info == x && raiz.hijoIzq.ArbolVacio())
                {
                    raiz.info = this.menor(raiz.hijoDer);
                    raiz.hijoDer.EliminarElem(raiz.info);
                }
                else if(raiz.info < x)
                {
                    raiz.hijoDer.EliminarElem(x);
                }
                else
                {
                    raiz.hijoIzq.EliminarElem(x);
                }
            }
        }

        public int mayor(ABBTDA a)
        {
            if (a.HijoDer().ArbolVacio())
            {
                return a.Raiz();
            }
            else
            {
                return mayor(a.HijoDer());
            }
        }

        public int menor(ABBTDA a)
        {
            if (a.HijoIzq(). ArbolVacio())
            {
                return a.Raiz();
            }
            else
            {
                return menor(a.HijoIzq());
            }
        }
    }

}

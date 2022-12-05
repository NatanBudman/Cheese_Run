using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : MonoBehaviour
{
    public static int Partition(LevelInfo[] array, int left, int right)
    {
        int pivot;
        int aux = (left + right) / 2;   //tomo el valor central del vector
        pivot = array[aux].Level;

        // en este ciclo debo dejar todos los valores menores al pivot
        // a la izquierda y los mayores a la derecha
        while (true)
        {
            while (array[left].Level < pivot)
            {
                left++;
            }
            while (array[right].Level > pivot)
            {
                right--;
            }
            if (left < right)
            {
                LevelInfo temp = array[right];
                array[right] = array[left];
                array[left] = temp;
            }
            else
            {
                // este es el valor que devuelvo como proxima posicion de
                // la particion en el siguiente paso del algoritmo
                return right;
            }
        }
    }
    public static void quickSort(LevelInfo[] array, int left, int right)
    {
        int pivot;
        if (left < right)
        {
            pivot = Partition(array, left, right);
            if (pivot > 1)
            {
                // mitad del lado izquierdo del vector
                quickSort(array, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                // mitad del lado derecho del vector
                quickSort(array, pivot + 1, right);
            }
        }
    }

}

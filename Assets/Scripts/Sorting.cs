using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RandomSort<T>(T[] a)
    {
        System.Random rnd = new System.Random();
        for (int i = a.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(0, i + 1);
            T tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
            Debug.Log("Sort ended " + i);
        }
    }
}

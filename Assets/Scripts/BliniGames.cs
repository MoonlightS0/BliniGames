﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BliniGames : MonoBehaviour
{
    //! *Метод получает в качестве аргументов два массива типа GameObject[]:
    //!1. Массив произвольного размера. ЛЮБОЙ элемент массива может содержать ссылку на Game Object или null.
    //!2. Массив произвольного размера, заполненный ссылками на GameObject.
    //Задание:
    //Разместить в СВОБОДНЫХ (содержащих null) элементах первого массива В СЛУЧАЙНОМ ПОРЯДКЕ ссылки на Game Object из второго массива, так,
    //чтобы все GameObject из второго массива были размещены (если только хватает места).
    //Оговорим условия, относящиеся к случайному порядку:
    //Если объектов из второго массива НЕ ХВАТАЕТ для заполнения всех свободных элементов первого массива, часть элементов первого массива остается
    //СВОБОДНЫМИ. Не должно быть так, чтобы сначала заполнялись, скажем, первые по порядку свободные элементы, т.е. не должно быть известно заранее, 
    //какие элементы окажутся заполнены, а какие останутся пустыми.
    //Если объектов из второго массива БОЛЬШЕ, чем свободных элементов в первом массиве, часть объектов из второго массива НЕ РАЗМЕЩАЕТСЯ. 
    //Не должно быть так, чтобы сначала размещались первые по порядку объекты из второго массива, т.е. в этом случае не должно быть известно заранее, 
    //какие элементы из второго массива окажутся размещены.


    // Start is called before the first frame update
    void Start()
    {
        //Methodgo();
    }

    // Update is called once per frame

    void Update()
    {
        
    }


    private void Methodgo(GameObject?[] arr,GameObject[] arr1)
    {
        arr = new GameObject[120];
        arr1 = new GameObject[100];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *Метод получает в качестве аргументов два массива типа GameObject[]:
//1. Массив произвольного размера. ЛЮБОЙ элемент массива может содержать ссылку на Game Object или null.
//2. Массив произвольного размера, заполненный ссылками на GameObject.
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

// *The method takes two arrays of type GameObject[] as arguments:
//1. An array of any size. ANY element of the array can contain a reference to a Game Object or null.
//2. An arbitrarily sized array filled with GameObject references.
//Task:
//Replace in the FREE (containing null) elements of the first array in a RUNNING way references to Game Object from the second array, so,
//so that all the GameObjects in the second array are placed (if only there is enough space).
//See the conditions relating to random order:
//If there are NOT enough objects from the second array to fill all the free elements of the first array, some of the elements of the first array remain
//FILLING ELEMENTS OF THE FIRST ARRAY. It shouldn't be so that the first free elements are filled first, say, in order, i.e. it shouldn't be known in advance //which elements will turn out to be free, 
//which elements will be filled, and which will be empty.
//If there are MORE objects in the second array than there are free elements in the first array, some of the objects in the second array are NOT LOCATED. 
//It should not be so that the first objects in order from the second array are placed first, i.e. in this case it should not be known beforehand, 
//which elements from the second array will be placed.

public class BliniGames : MonoBehaviour
{
    [Header("Size of arraays")]
    //[Range(1,120)]
    //[SerializeField]
    int sizeArrayIn = 120;
    //[Range(1,120)]
    //[SerializeField] 
    int sizeArrayOut = 15;

    // Start is called before the first frame update
    void Start()
    {
        MethodGO();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MethodGO()  //main method for replace FREE (containing null) elements.
    {
        GameObject?[] arr = new GameObject?[sizeArrayIn]; //array 
        
        //right now gameObject added manually
        arr[1] = gameObject;
        arr[2] = gameObject;
        arr[3] = gameObject;
        arr[4] = gameObject;

        GameObject[] arr1 = new GameObject[sizeArrayOut];
        Sorting.RandomSort(arr1);

        //int rValue = Random.Range(10, 110);
        //Debug.Log("Random number = "+ rValue);

        //for (var i = 0; i < sizeArrayOut; i++) //for random numbers of game objects in arr1
        //{

        //}

        for (var i = 0; i < sizeArrayOut; i++)
        {
            if (arr[i] == null)
            {
                Debug.Log("NULL " + i);
                arr[i] = arr1[i];
            }
            else if (arr[i] == gameObject)
            {
                Debug.Log("Array already have GameObject"+ i);
            }
        }
        Debug.Log("Check array");
        for (var i = 0; i < sizeArrayIn; i++) //checking an array for a result
        {
            if (arr1[i] == null)
            {
                Debug.Log("NULL " + i);
            }
            else if (arr1[i] == gameObject)
            {
                Debug.Log("Array already have GameObject"+ i);
            }
        }
    }
}

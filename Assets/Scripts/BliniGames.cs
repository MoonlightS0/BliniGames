using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random; //from unity docs Random - "Because the classes share the name Random, it can be easy to get a CS0104 "ambiguous reference" compiler error if the System and UnityEngine namespaces are both brought in via using"

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
    int sizeArrayFirstIn = 20;
    //[Range(1,120)]
    //[SerializeField] 
    int sizeArraySecondOut = 10;
    public GameObject inst_second_arr;
    public GameObject?[] first_arr;
    public GameObject[] second_arr;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject?[] first_arr = new GameObject?[sizeArrayFirstIn]; //first array
        first_arr = new GameObject?[sizeArrayFirstIn]; //first array
        second_arr = new GameObject[sizeArraySecondOut];
        //adding in first array gameObjects 
        first_arr[0] = gameObject;
        first_arr[1] = gameObject;
        first_arr[2] = gameObject;
        first_arr[3] = gameObject;

        for (var i = 0; i < sizeArraySecondOut; i++) //instantiate 2nd array
        {
            GameObject go = Instantiate(inst_second_arr, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
            go.transform.localScale = Vector3.one;
            second_arr[i] = go;
        }

        MethodGO(first_arr, second_arr);
        //Check();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MethodGO(GameObject[]? f_arr, GameObject[] s_arr)  //main method for replace FREE (containing null) elements.
    {
        bool[] ConfirmationArray = new bool[sizeArraySecondOut];
        int mrk = 10;
        //Sorting.RandomSort(second_arr);
        //int rValue = Random.Range(10, 110);
        //Debug.Log("Random number = "+ rValue);

        int s = 0 ; // value for corretly working cicle
        //int r = Random.Range(0, sizeArrayFirstIn);

        for (var i = 0; i < sizeArrayFirstIn; i++) 
        {
            try //for ignoring exception 
            {
                if (f_arr[i] == null)
                {
                    BEGIN:
                    int RandomNumber = Random.Range(0, s_arr.Length);
                    if (ConfirmationArray[RandomNumber] == true)
                    {
                        Debug.Log("Go to BEGIN(RandomNumber) = " + RandomNumber);
                        //if (ConfirmationArray[0] == true && ConfirmationArray[1] == true && ConfirmationArray[2] == true && ConfirmationArray[3] == true && ConfirmationArray[4] == true && ConfirmationArray[5] == true && ConfirmationArray[6] == true && ConfirmationArray[7] == true && ConfirmationArray[8] == true && ConfirmationArray[9] == true)
                        if (i == s_arr.Length)
                        {
                            break;
                        }
                        else
                        {
                            goto BEGIN;
                        }
                    }
                    else if (ConfirmationArray[RandomNumber] == false)
                    {
                        f_arr[i] = s_arr[s];
                        ConfirmationArray[RandomNumber] = true; //mark numbers
                        //mrk = mrk + 1;


                        Debug.Log("NULL " + i);
                        if (s < sizeArraySecondOut)
                        {
                            Debug.Log("s = " + s);
                            s++;
                        }
                    }
                    else
                    {
                        Debug.Log("ERROR - BULL HAVE STRANGE STATE" + s);
                    }
                }
                else if (f_arr[i] == gameObject)
                {
                    Debug.Log("Array already have GameObject " + i);
                }

            }
            catch (IndexOutOfRangeException)
            {
                Debug.Log("Array ended." + i);
                //Debug.LogException(e, this);  
            }
            finally //if no exception
            {

            }

        }

        Debug.Log("Check array STARTED");
        for (var i = 0; i < sizeArrayFirstIn; i++) //checking first array for a result
        {
            if (first_arr[i] == null)
            {
                Debug.Log("NULL " + i);
            }
            else if (first_arr[i] == gameObject)
            {
                Debug.Log("Array already have GameObject " + i);
            }
            else if (first_arr[i].tag=="PrefabGameObj")
            {
                Debug.Log("gameObject type(PrefabGameObj )" + i);
            }
            else
            {
                Debug.Log("Another type " + i);
            }
        }
    }

    //private void Check()
    //{
    //    Debug.Log("Check array");
    //    GameObject[] second_arr = new GameObject[sizeArrayOut];
    //    for (var i = 0; i < sizeArrayIn; i++) //checking an array for a result
    //    {
    //        if (second_arr[i] == null)
    //        {
    //            Debug.Log("NULL " + i);
    //        }
    //        else if (second_arr[i] == gameObject)
    //        {
    //            Debug.Log("Array already have GameObject "+ i);
    //        }
    //    }
    //}
}
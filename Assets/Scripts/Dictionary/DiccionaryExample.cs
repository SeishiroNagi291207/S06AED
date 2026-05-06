using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    public Dictionary<int, string> pokemones = new();


    void Start()
    {
        pokemones.Add(1, "Bulbasur");
        pokemones.Add(354, "Bannete");
        pokemones.Add(85, "Dodrio");


        if (pokemones.TryAdd(25, "Bulbasur"))
        {
            Debug.Log("exito");
        }
        else
        {
            Debug.Log("error");
        }

        Debug.Log(pokemones[63]);


        if (pokemones.TryGetValue(85, out string x))
        {
            Debug.Log(x);
        }
        else
        {
            Debug.Log("error");
        }


    }


    void Update()
    {

    }
    /*
    [Button]
    public void GetHashing()
    {
        int LargoDic = 10;
        string x = "PedroPablo";

        Debug.Log(x.GetHashCode());

        Debug.Log("Su indice seria: " + (Mathf.Abs(x.GetHashCode()) % LargoDic));//->blockchain :D
    }*/
}
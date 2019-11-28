using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noDestroy : MonoBehaviour
{
    [SerializeField]
    GameObject som;
    GameObject[] sons;

    
  
    private void Awake()
    {
        sons = GameObject.FindGameObjectsWithTag("music");

        if(sons.Length == 0)
        {
            GameObject somInstanciado = Instantiate(som);
            DontDestroyOnLoad(SomInstanciado);
            print("dfdf");
        }
    }
}

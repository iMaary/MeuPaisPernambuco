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
        //DontDestroyOnLoad(this.gameObject);
        sons = GameObject.FindGameObjectsWithTag("music");
        
        if(sons.Length == 0)
        {
            GameObject SomInstanciado = Instantiate(som);
            DontDestroyOnLoad(SomInstanciado);
            print("dfdf");
        }
    }
}

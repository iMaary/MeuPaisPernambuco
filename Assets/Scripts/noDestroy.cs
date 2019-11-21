using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noDestroy : MonoBehaviour
{
    GameObject som;
  
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        som = GameObject.FindGameObjectWithTag("music");
        print("dfdf");

        //se som já foi instanciado, destrua o novo.
        
    }
}

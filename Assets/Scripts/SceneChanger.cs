using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private AudioSource btnCreditos; 
     

    public void ChangeScene(string sceneName)
    {
        btnCreditos = GetComponent<AudioSource>();
        //btnVoltar = GetComponent<AudioSource>();
        btnCreditos.Play();
        SceneManager.LoadScene(sceneName);
        
        
    }
}

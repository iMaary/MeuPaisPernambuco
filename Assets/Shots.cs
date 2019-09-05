using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shots : MonoBehaviour
{
    public GameObject bala;
    //[SerializeField]private float speed;

    public void atirar()
    {
        Vector3 m = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(bala, m, Quaternion.identity);
        
    }
}

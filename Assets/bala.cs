using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick joystick1;
    [SerializeField] private GameObject top;

    void Update()
    {
        // transform.Translate(Vector3.right * speed * Time.deltaTime);
        Vector2 direcao = new Vector2(joystick1.Horizontal, joystick1.Vertical);

        float angle = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        print(angle);
        transform.Translate(direcao * speed * Time.deltaTime);
  
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        //Vector3 joystickposition = new Vector3(joystick.Horizontal, joystick.Vertical);
        //joystickposition.Normalize();
        //float angle = Mathf.Atan2(joystickposition.y, joystickposition.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        
    }
}
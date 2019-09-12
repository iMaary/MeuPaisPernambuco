using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public FixedJoystick joystick;
    public GameObject bala;
    void Update()
    {
        Vector3 joystickposition = new Vector3(joystick.Horizontal, joystick.Vertical);
        joystickposition.Normalize();
        float angle = Mathf.Atan2(joystickposition.y, joystickposition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        bala.transform.rotation = Quaternion.Euler(0, 0, angle); 

        if (Input.GetKeyDown("space"))
        {
            Atirar(angle);
        }
    }

    void Atirar(float angle)
    {
        Vector3 m = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(bala, m, bala.transform.rotation);
        //bala.transform.rotation = Quaternion.Euler(0, 0, angle);
        //bala.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
}

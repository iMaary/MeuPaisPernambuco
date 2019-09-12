using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //[SerializeField]private FixedJoystick joystick;
    [SerializeField] private FloatingJoystick floatingJoystick;
    public GameObject bala;
    private GameObject joystick;
    private float fireRate = 0.5f, nextFire = 0f;
    void Update()
    {
        Vector3 joystickposition = new Vector3(floatingJoystick.Horizontal, floatingJoystick.Vertical);
        joystickposition.Normalize();
        float angle = Mathf.Atan2(joystickposition.y, joystickposition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        bala.transform.rotation = Quaternion.Euler(0, 0, angle);
        joystick = GameObject.FindGameObjectWithTag("joystick");
        if (joystick != null)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Atirar(angle);
            }
        }
    }

    void Atirar(float angle)
    {
        Vector3 m = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(bala, m, bala.transform.rotation);
    }
}

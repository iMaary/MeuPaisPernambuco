using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private float moveHoriz, moveVert;
    [SerializeField] private Joystick joystick;

    void Update()
    {
        Movement();
        Vector2 direcao = new Vector2(joystick.Horizontal, joystick.Vertical);
        float angle = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        transform.Rotate(0, 0, angle);
    }

    private void Movement()
    {
        moveHoriz = joystick.Horizontal * speed;
        moveVert = joystick.Vertical * speed;

        transform.Translate(Vector3.right * moveHoriz * Time.deltaTime);
        transform.Translate(Vector3.up * moveVert * Time.deltaTime);
       

        moveHoriz = (joystick.Horizontal >= 0.3f) ? speed: (joystick.Horizontal <= -0.3f)? -speed : 0f;
        moveVert = (joystick.Horizontal >= 0.3f) ? speed : (joystick.Horizontal <= -0.3f) ? -speed : 0f;
    }
}

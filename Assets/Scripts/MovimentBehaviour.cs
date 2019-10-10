using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private float moveHoriz, moveVert;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Image img;
    [SerializeField]private Rigidbody2D rb;
    private bool movimento;
    [SerializeField] private Inimigo inimigo;
    private bool movInimigo;

    private void Start()
    {
        movimento = true;
        movInimigo = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            img.fillAmount -= 0.2f;
        }
        Movement(movimento);
    }

    private void Movement(bool x)
    {
        if(x)
            {
            moveHoriz = joystick.Horizontal * speed;
            moveVert = joystick.Vertical * speed;

            transform.Translate(Vector3.right * moveHoriz * Time.deltaTime);
            transform.Translate(Vector3.up * moveVert * Time.deltaTime);


            moveHoriz = (joystick.Horizontal >= 0.3f) ? speed : (joystick.Horizontal <= -0.3f) ? -speed : 0f;
            moveVert = (joystick.Horizontal >= 0.3f) ? speed : (joystick.Horizontal <= -0.3f) ? -speed : 0f;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "balaInimigo")
        {
            print("blbablalblabl");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            movimento = false;
            movInimigo = false;
        }
        else
        {
           
        }
    }
}

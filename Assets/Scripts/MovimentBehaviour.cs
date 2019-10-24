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
    public bool movInimigo;
    private float clickAtual;
    private float clickAnterior = -1000;
    private bool putz;


    private void Start()
    {
        putz = false;
        movimento = true;
        movInimigo = true;
    }

    void Update()
    {
       
        Movement(movimento);
        preso(putz);
    }

    private void Movement(bool x)
    {
        if(x)
        {
            moveHoriz = joystick.Horizontal;
            moveVert = joystick.Vertical;

            Vector3 movement = new Vector3(moveHoriz, moveVert, 0.0f);
            rb.velocity = movement * speed;

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
            putz = true;
            
        }
        else
        {
           
        }
    }

    void preso(bool vra)
    {
        if(vra)
        {
            if (Input.GetKeyDown("space"))
            {
                clickAtual = Time.time;
                if (clickAtual - clickAnterior < 1f)
                {
                    print("putz");
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    movimento = true;
                    putz = false;
                    img.fillAmount -= 0.4f;
                }
                clickAnterior = clickAtual;
                
            }
        }
        
    }
}

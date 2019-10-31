using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimentBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    private float moveHoriz, moveVert;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Image barraForca;
    [SerializeField]private Rigidbody2D rb;
    private bool movimento;
    [SerializeField] private Inimigo inimigo;
    public bool movInimigo;
    private float clickAtual;
    private float clickAnterior = -1000;
    private bool espaco;
    private int forca;
    private GameObject[] balaInimigo;


    private void Start()
    {
        espaco = false;
        movimento = true;
        movInimigo = true;
        forca = 3;
    }

    void Update()
    {
       
        Movement(movimento);
        preso(espaco);
        if(forca == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
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
            barraForca.fillAmount -= 0.4f;
            forca--;
            movimento = false;
            movInimigo = false;
            espaco = true;
            balaInimigo = GameObject.FindGameObjectsWithTag("balaInimigo");

            foreach (GameObject bala in balaInimigo)
            {
                Destroy(bala);
            }


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
                    print("espaco");
                    rb.constraints = RigidbodyConstraints2D.None;
                    rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                    movimento = true;
                    espaco = false;
                    StartCoroutine(Inimigo());                   
                   
                }
                clickAnterior = clickAtual;
                
            }
        }
        
    }
    IEnumerator Inimigo()
    {
        yield return new WaitForSeconds(2);
        movInimigo = true;
    }
}


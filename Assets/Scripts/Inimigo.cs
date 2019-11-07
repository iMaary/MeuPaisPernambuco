using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{  
    [SerializeField] private float speed, fireRate = 0.9f, nextFire = 0f;
    private float dx, dy;
    public GameObject player, bala;
    private bool playerCollider, playerShootCollider, movimento;
    private Transform target;
    private Rigidbody2D rb, rbPlayer;
    private MovimentBehaviour movimentBehaviour;
    private Animator atr;
    private SpriteRenderer sr;


    private void Awake()
    {
        atr = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        movimento = true;
        movimentBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentBehaviour>();
    }

    private void Update()
    {
        movimento = movimentBehaviour.GetComponent<MovimentBehaviour>().movInimigo;
        playerCollider = Physics2D.OverlapCircle(transform.position, 3.5f, LayerMask.GetMask("Player"));
        playerShootCollider = Physics2D.OverlapCircle(transform.position, 5f, LayerMask.GetMask("Player"));
        if (playerShootCollider && movimento)
        {
            Movimento();
        }
     
    }


    void Atirar()
    {
        if(playerCollider)
        {
            Vector3 m = new Vector3(transform.position.x, transform.position.y, -1);
            Instantiate(bala, m, Quaternion.identity);
        }
              
    }

    void Movimento()
    {
        if(playerCollider)
        {
            print(playerCollider);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
   
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Atirar();
        }
        dx = Mathf.Abs(player.transform.position.x);
        dy = Mathf.Abs(player.transform.position.y);
        if (player.transform.position.x < transform.position.x && dy < dx)
        {
            sr.flipX = true;
            atr.SetBool("Up", false);
            atr.SetBool("Down", false);
            atr.SetBool("Horizontal", true);
        }
        else if (player.transform.position.x > transform.position.x && dy < dx)
        {
            sr.flipX = false;
            atr.SetBool("Up", false);
            atr.SetBool("Down", false);
            atr.SetBool("Horizontal", true);
        }
        else if (player.transform.position.y > transform.position.y && dy > dx)
        {
            atr.SetBool("Up", true);
            atr.SetBool("Down", false);
            atr.SetBool("Horizontal", false);
        }
        else if (player.transform.position.y < transform.position.y && dy > dx) {
            atr.SetBool("Up", false);
            atr.SetBool("Down", true);
            atr.SetBool("Horizontal", false);
        }
        else
        {
            atr.SetBool("Up", false);
            atr.SetBool("Down", false);
            atr.SetBool("Horizontal", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bala")
        {
            Destroy(this.gameObject);
        }
    }

}

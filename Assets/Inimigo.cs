using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{  
    [SerializeField] private float speed, fireRate = 0.9f, nextFire = 0f;
    public GameObject player;
    private bool playerCollider;  
    private Transform target;
    private Rigidbody2D rb, rbPlayer;
    public GameObject bala;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
   
    }
    private void Update()
    {
        Vector3 posicao = new Vector3(target.position.x, target.position.y);
        float angle = Mathf.Atan2(posicao.y, posicao.x) * Mathf.Rad2Deg;
        bala.transform.rotation = Quaternion.Euler(0, 0, angle);
        bala.GetComponent<BalaInimigo>().target = this.target;
        Ataque();
    }


    void Atirar()
    {
        Vector3 m = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(bala, m, bala.transform.rotation);       
    }

    void Ataque()
    {
        playerCollider = Physics2D.OverlapCircle(transform.position, 3.5f, LayerMask.GetMask("Player"));
        print(playerCollider);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (playerCollider && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Atirar();
        }
    }

        //if (Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //}
}

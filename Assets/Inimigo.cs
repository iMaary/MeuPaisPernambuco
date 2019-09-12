﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{  
    [SerializeField] private float speed, fireRate = 0.9f, nextFire = 0f;
    public GameObject player;
    private bool playerCollider;
    private bool playerShootCollider;
    private Transform target;
    private Rigidbody2D rb, rbPlayer;
    public GameObject bala;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        playerCollider = Physics2D.OverlapCircle(transform.position, 3.5f, LayerMask.GetMask("Player"));
        playerShootCollider = Physics2D.OverlapCircle(transform.position, 5f, LayerMask.GetMask("Player"));
        if (playerShootCollider)
        {
            Ataque();
        }
        
    }


    void Atirar()
    {
        Vector3 m = new Vector3(transform.position.x, transform.position.y, -1);
        Instantiate(bala, m, Quaternion.identity);       
    }

    void Ataque()
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
    }
}

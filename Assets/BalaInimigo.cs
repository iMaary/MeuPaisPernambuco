using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaInimigo : MonoBehaviour
{
    public Transform target;
    private float speed = 5f;
    private void Start()
    {
        Invoke("Destroi", 1.5f);
    }
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }

    void Destroi()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroi();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtul : MonoBehaviour
{
    public float turtulbounce;
    public float cooldown = 0.1f;
    private float currentstun;
    public float stuntime;
    private Rigidbody2D rb;
    public float movespeed;
    public Transform raycast;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        currentstun -= Time.deltaTime;
        cooldown -= Time.deltaTime;
        if(currentstun < 0)
        {
            move();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    void move()
    {
        rb.velocity = new Vector2(movespeed * transform.localScale.x * -1, rb.velocity.y);
        RaycastHit2D rayout = Physics2D.Linecast(transform.position, raycast.position);
        if (rayout)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }


    }
    public void Jump(float force)
    {
        currentstun = stuntime;
        rb.velocity = new Vector2(rb.velocity.x, force);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && cooldown < 0)
        {
            cooldown = 0.1f;
            collision.gameObject.GetComponent<Player>().Jump(turtulbounce);
        }
    }
}

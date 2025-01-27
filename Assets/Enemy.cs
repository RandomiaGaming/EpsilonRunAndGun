using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage(damage);
        }
    }

    public void Damage(int damage)
    {

        GetComponent<Animator>().Play("ouch");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

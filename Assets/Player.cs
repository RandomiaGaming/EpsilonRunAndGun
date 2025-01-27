using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public Vector2 knockback;
    public float moveforce;
    public float jumpforce;
    public int damage;
    public float bulletspeed;
    public int health;
    public float timebtwshots;
    public groundchecker groundcheck;
    public Sprite up;
    public Sprite down;
    private Sprite normal;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public GameObject Bullet;
    public Gun gun;
    private float shoottimer = 0;
    public Transform sprite;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        normal = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(shoottimer > 0)
        {
            shoottimer -= Time.deltaTime;
        }
        if (health <= 0)
        {

            Die();
        }
        if (groundcheck.Grounded && Input.GetButtonDown("Jump"))
        {
            Jump(jumpforce);
        }
        if (Input.GetButton("Shoot") && shoottimer <= 0)
        {
            Shoot();
        }
        rb.velocity = new Vector2(moveforce * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        
        if(gun.gameObject.transform.right.x * -1 > 0)
        {
            sprite.localScale = new Vector3(-1, sprite.localScale.y, sprite.localScale.z);
        }
        else
        {
            sprite.localScale = new Vector3(1, sprite.localScale.y, sprite.localScale.z);
        }
    }

    void OnBecameInvisible()
    {
        Die();
    }
   public void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, force);
        
    }
    void Die()
    {
        print("Player died");
        
    }
    void Shoot()
    {
        shoottimer = timebtwshots;
       GameObject bulletclone = Instantiate(Bullet, gun.transform.position + (gun.transform.right * -1), Quaternion.identity);
        bulletclone.GetComponent<Bullet>().speed = bulletspeed;
        bulletclone.GetComponent<Bullet>().forward = gun.gameObject.transform.right * -1;
        bulletclone.GetComponent<Bullet>().damage = damage;
    }
    public void Damage(int damage)
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("ouch"))
        {
            
            GetComponent<Animator>().Play("ouch");
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }
}

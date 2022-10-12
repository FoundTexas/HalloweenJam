using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    bool b;
    public float speed;
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        b = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed * Time.deltaTime;

        if (!b)
        {
            float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x - 1;
            if(transform.position.x < minWidth)
            {
                Destroy(this.gameObject);
            }
        }
        else if (b)
        {
            float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x + 1;
            if (transform.position.x > maxWidth)
            {
                Destroy(this.gameObject);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Transformacion");
        if (!b)
        {
            FindObjectOfType<Player>().AddScore();
            GetComponent<AudioSource>().Play();
            anim.SetTrigger("pig");
            CircleCollider2D c = GetComponent<CircleCollider2D>();
            c.isTrigger = true;
            b = true;
            speed *= -2;
        }
    }
}

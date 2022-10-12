using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int s,cs;
    public float t;
    bool b = false;
    bool Ground;
    bool damaged;
    public Sprite[] Sprites;
    SpriteRenderer SR;
    public AudioClip[] hurt, laugh;
    public int health;
    public float force, minWidth, maxWidth;
    public Rigidbody2D rb;
    AudioSource audios;
    public GameObject[] Hearts;
    bool dead = false;
    public GameObject St,Score,Spawn,Spawn2, bow;
    public Text ScoreT;
    public bool start = false;

    void Start()
    {
        t = 2;
        start = false;
        damaged = false;
        SR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audios = GetComponent<AudioSource>();
        Ground = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (!start && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
            {
                start = true;
                Spawn.SetActive(true);
                Spawn2.SetActive(true);
                St.SetActive(false);
                bow.SetActive(true);
            }
        }
    }

    public void TakeDMG()
    {
        if (!damaged)
        {
            damaged = true;
            StartCoroutine(Hurted());
            audios.clip = hurt[Random.Range(0, hurt.Length)];
            audios.Play();
            health--;
            //camAnim.SetTrigger("shake");
            //Instantiate(moveEffect, transform.position, Quaternion.identity);
            if (health <= 0)
            {
                if (!b)
                {
                    b = true;
                    bow.SetActive(false);
                    Spawn.SetActive(false);
                    Spawn2.SetActive(false);
                    // FindObjectOfType<SceneLoader>().restart();
                    dead = true;
                    start = false;
                    Score.SetActive(true);
                }
            }
            for (int i = 0; i < Hearts.Length; i++)
            {
                if (health > i)
                {
                    Hearts[i].GetComponent<Image>().enabled = true;

                }
                else
                {
                    Hearts[i].GetComponent<Image>().enabled = false;
                }
            }
        }
    }

    IEnumerator Hurted()
    {
        SR.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        SR.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        SR.color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.2f);
        SR.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        SR.color = new Color(1, 0, 0);

        yield return new WaitForSeconds(0.2f);
        SR.color = new Color(1, 1, 1);
        damaged = false;
    }

    public void AddHP()
    {
        audios.clip = laugh[Random.Range(0, laugh.Length)];
        audios.Play();
        health++;
        //Instantiate(moveEffect, transform.position, Quaternion.identity);
        if (health >= 3)
        {
            health = 3;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (health > i)
            {
                Hearts[i].GetComponent<Image>().enabled = true;

            }
            else
            {
                Hearts[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    public void AddScore()
    {
        s++;
        cs++;
        ScoreT.text = s+"";
        if (cs >= 30)
        {
            cs = 0;
            AddHP();
        }
    }

    private void FixedUpdate()
    {
        if (start)
        {
            //rb.velocity = Vector2.zero;
            rb.AddForce((Vector2.right) * force * 6);

            if (Input.GetKey("left") || Input.GetKey("a"))
            {

                rb.AddForce((Vector2.left) * force * 30, ForceMode2D.Force);
            }
            else if (Input.GetKey("right") || Input.GetKey("d"))
            {
                rb.AddForce((Vector2.right) * force * 20, ForceMode2D.Force);
            }

            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                SR.sprite = Sprites[0];
                rb.velocity = Vector2.zero;
                rb.AddForce((Vector2.up) * force, ForceMode2D.Impulse);
            }
            else
            {
                rb.velocity = Vector2.zero;
                rb.AddForce((Vector2.down) * force / 2, ForceMode2D.Impulse);
                if (!Ground)
                {
                    SR.sprite = Sprites[2];
                    if (t < 2)
                    {
                        t += Time.deltaTime / 4;
                    }
                    
                }
                
            }

            if (Input.GetKey("down") || Input.GetKey("s"))
            {
                SR.sprite = Sprites[2];
                rb.velocity = Vector2.zero;
                rb.AddForce((Vector2.down) * force, ForceMode2D.Impulse);
            }

            minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x - 1;
            maxWidth = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width), 0, 10)).x-1f;

            float minh = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).y;
            float maxh = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 10)).y - 1f;
            

            rb.position = new Vector2(Mathf.Clamp(rb.position.x, minWidth, maxWidth),
                    Mathf.Clamp(rb.position.y, minh, maxh));
            if (rb.position.x <= minWidth + 0.1)
            {
                health = 0;
                TakeDMG();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Ground = true;
        }
        rb.AddForce((Vector2.right) * force * -30, ForceMode2D.Force);
        SR.sprite = Sprites[1];
        t -= Time.deltaTime;
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        t -= Time.deltaTime;
        rb.AddForce((Vector2.right) * force * -30);
        if (t <= 0)
        {
            t = 2;
            TakeDMG();
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Ground = false;
    }
}

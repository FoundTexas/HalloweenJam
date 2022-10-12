using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed;
    public GameObject effect;
    public BoxCollider2D bc;

    public bool HP;

	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            if (!HP)
            {
               collision.gameObject.GetComponent<Player>().TakeDMG();
            }
            else if (HP)
            {
                collision.gameObject.GetComponent<Player>().AddHP();
            }
            //other.GetComponent<Player>().camAnim.SetTrigger("shake");
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }   
    }
}

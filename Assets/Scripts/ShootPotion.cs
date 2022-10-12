using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootPotion : MonoBehaviour
{

    public GameObject arrow;
    public float launchForce, TBS;
    float curTBS;
    public Transform shotPoint;
    public Slider coolDown;


    void Start()
    {
        curTBS = 0;
        coolDown.maxValue = TBS;
        coolDown.value = 0;
        coolDown.gameObject.SetActive(false);
    }

    void Update()
    {
        /*Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;*/

        if ((Input.GetMouseButtonDown(0)||Input.GetKeyDown("space")) && curTBS < 0)
        {
            coolDown.gameObject.SetActive(true);
            curTBS = TBS;
            coolDown.value = curTBS;
            Shoot();
        }
        else if(curTBS >= 0)
        {
            curTBS -= Time.deltaTime;
            coolDown.value = curTBS;
        }
        else if(curTBS < 0)
        {
            coolDown.gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}

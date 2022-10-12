using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteParallax : MonoBehaviour
{
    public Texture text1;
    public bool playX, playY;
    Material material;
    public Vector2 offset, last;
    public Spawner target;

    public float xVel, yVel;
    public float MxVel, MyVel;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVel, yVel);
    }

    public void acelerate()
    {
    }

    // Update is called once per frame
    void Update()
    {

        offset = new Vector2(target.addspeed/10 / xVel, yVel);
        last += offset * Time.deltaTime;
        material.SetVector("offset_1", last);


    }
    }

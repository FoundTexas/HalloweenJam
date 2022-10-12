using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public bool playX, playY;
    Material material;
    public Vector2 offset;
    public Spawner target;

    public float xVel, yVel;
    public float MxVel, MyVel;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
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

        offset = new Vector2(target.addspeed/xVel, yVel);
        material.mainTextureOffset += offset * Time.deltaTime;


    }
}

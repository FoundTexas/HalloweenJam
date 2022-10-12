using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float minTime,maxspeed;

    public float addspeed = 1;

    public GameObject[] obstacleTemplate;

    private void Start()
    {
        timeBtwSpawns = -1;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, obstacleTemplate.Length);
            GameObject g = Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
            ObstacleSpawn[] children = g.GetComponentsInChildren<ObstacleSpawn>();

            foreach (ObstacleSpawn o in children)
            {
                o.sp = addspeed;
            }

            Pig p = g.GetComponent<Pig>();
            if (p != null)
            {
                p.speed = addspeed * 10;
                timeBtwSpawns = Random.Range(minTime, maxspeed);
            }
            else {
                timeBtwSpawns = startTimeBtwSpawns;
            }

            if (startTimeBtwSpawns > minTime) {
                startTimeBtwSpawns -= timeDecrease;
            }
            if(addspeed < maxspeed)
            {
                addspeed += 0.05f;
            }
        }
        else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

}

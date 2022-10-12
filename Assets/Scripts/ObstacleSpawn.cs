using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

    public GameObject[] obstacle;

    public bool HPorNot, house;

    public float sp;

    private void Start()
    {
        if (house)
        {
            GameObject o = Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position, Quaternion.identity);
            o.GetComponent<Obstacle>().speed *= sp*2/3;
        }
        else
        {
            if (!HPorNot)
            {
                GameObject o = Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position, Quaternion.identity);
                o.GetComponent<Obstacle>().speed *= sp;
            }
            else if (HPorNot)
            {
                int i = Random.Range(0, 3);
                switch (i)
                {
                    case 2:
                        GameObject o = Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position, Quaternion.identity);
                        o.GetComponent<Obstacle>().speed *= sp;
                        break;
                    case 0:
                        GameObject o2 = Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position, Quaternion.identity);
                        o2.GetComponent<Obstacle>().speed *= sp;
                        break;

                }
            }
        }
    }
}

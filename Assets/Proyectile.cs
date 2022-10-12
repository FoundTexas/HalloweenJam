using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    public GameObject PE;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(PE,this.transform.position,Quaternion.identity ,null);
        Destroy(this.gameObject);
    }
}

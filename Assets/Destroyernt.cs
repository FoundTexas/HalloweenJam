using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyernt : MonoBehaviour
{
    public static GameObject inst;
    // Start is called before the first frame update
    void Start()
    {
        if (inst == null)
        {
            inst = this.gameObject;
        }

        if (inst != this.gameObject)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

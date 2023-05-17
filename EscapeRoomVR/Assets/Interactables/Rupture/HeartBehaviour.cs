using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    public int nbCoup = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "hammer")
        {
            nbCoup--;
            if (nbCoup <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PontFiniBehaviour : MonoBehaviour
{
    public PlayableDirector director;

    
    public void spawn(Transform trans)
    {
        transform.position = trans.position;
        director.Play();
        transform.GetComponent<Rigidbody>().isKinematic = false;
        transform.GetComponent<Rigidbody>().useGravity = true;
    }

}

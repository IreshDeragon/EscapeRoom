using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BrokentHeartBehaviour : MonoBehaviour
{
    public PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        director.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

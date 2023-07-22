using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BrokentHeartBehaviour : MonoBehaviour
{
    public PlayableDirector director;
    double time;
    double timer;
    // Start is called before the first frame update
    void Start()
    {
        director.Play();
        time = director.duration;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= time)
        {
            Destroy(gameObject);
        }
    }
}

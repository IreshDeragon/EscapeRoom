using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PontFiniBehaviour : MonoBehaviour
{
    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        director.Play();

    }

}

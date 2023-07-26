using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PontBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pontFini;
    public PlayableDirector director;

    public void completed(Transform trans)
    {
        pontFini.GetComponent<PontFiniBehaviour>().spawn(trans);
        
        Destroy(gameObject);
    }
}

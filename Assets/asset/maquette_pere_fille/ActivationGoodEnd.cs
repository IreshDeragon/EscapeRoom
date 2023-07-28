using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivationGoodEnd : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject fille;
    bool hasPlayed = false;

    public void activate()
    {
        if (!hasPlayed)
        {
            fille.GetComponent<FilleBehaviour>().setPlayCry(false);
            gameObject.layer = 0;
            hasPlayed = true;
            director.Play();
        }
    }
}

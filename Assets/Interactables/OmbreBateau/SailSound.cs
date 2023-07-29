using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailSound : MonoBehaviour
{
    public bool snaped;

    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;
    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBoat/IG_PB_take_sailboat");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBoat/IG_PB_fallen_sailboat");
    }

    public void pickSound()
    {
        pickEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pickEvent.start();
    }
    public void placeSound()
    {
        fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        fallEvent.start();
    }

    public void setSnaped(bool snap)
    {
        snaped = snap;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "decors" && !snaped)
        {
            fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            fallEvent.start();
        }
    }
}

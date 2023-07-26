using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSound : MonoBehaviour
{
    public bool snaped;
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;
    private FMOD.Studio.EventInstance placeEvent;
    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_take_picture");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_pose_picture");
        placeEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_pose_picture");
    }

    public void pickSound()
    {
        pickEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pickEvent.start();
    }
    public void placeSound()
    {
        placeEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        placeEvent.start();
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

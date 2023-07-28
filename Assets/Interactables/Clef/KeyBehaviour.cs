using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject handGrab;
    public GameObject handGrabMirror;

    public bool snaped;

    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;

    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/Common/IG_C_take_key");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/Common/IG_C_pose_key");
    }
    public void disableGrab()
    {
        handGrab.SetActive(false);
        handGrabMirror.SetActive(false);
        setSnaped(true);
        placeSound();
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

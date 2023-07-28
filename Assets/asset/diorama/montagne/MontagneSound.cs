using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontagneSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;

    public bool snaped;

    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_take_stone_heart");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_pose_stone_heart");
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
        placeSound();
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

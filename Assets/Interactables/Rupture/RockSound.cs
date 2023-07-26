using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;
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

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "decors")
        {
            fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            fallEvent.start();
        }
    }
}

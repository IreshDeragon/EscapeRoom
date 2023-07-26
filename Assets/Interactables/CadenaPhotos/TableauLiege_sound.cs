using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauLiege_sound : MonoBehaviour
{
    //sons
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;

    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_take_cork_board");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_pose_cork_board");
    }

    public void pickSound()
    {
        pickEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pickEvent.start();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "decors")
        {
            fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            fallEvent.start();
        }
    }
}

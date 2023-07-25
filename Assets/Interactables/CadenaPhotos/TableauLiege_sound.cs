using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauLiege_sound : MonoBehaviour
{
    //sons
    private FMOD.Studio.EventInstance pickEvent;
    
    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_take_cork_board");
    }

    public void pickSound()
    {
        pickEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pickEvent.start();
    }
}

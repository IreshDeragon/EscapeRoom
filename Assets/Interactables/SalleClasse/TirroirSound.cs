using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirroirSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance grabEvent;
    void Start()
    {
        grabEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleClassroom/IG_PC_resolved");
    }
    public void grabSound()
    {
        grabEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        grabEvent.start();
    }
}

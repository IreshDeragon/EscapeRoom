using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance correctEvent;


    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBridgeReconstruction/IG_PBR_take_bridge_piece");
        correctEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBridgeReconstruction/IG_PBR_correct_bridge_piece_assembly");
    }

    public void pickSound()
    {
        pickEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pickEvent.start();
    }
    public void assembleSound()
    {
        correctEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        correctEvent.start();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontSound : MonoBehaviour
{
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance correctEvent;
    private FMOD.Studio.EventInstance fallEvent;

    public bool snaped;


    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBridgeReconstruction/IG_PBR_take_bridge_piece");
        correctEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBridgeReconstruction/IG_PBR_correct_bridge_piece_assembly");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBridgeReconstruction/IG_PBR_pose_bridge_piece");
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

    public void setSnaped(bool snap)
    {
        snaped = snap;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "decors" && !snaped)
        {
            fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            fallEvent.start();
        }
    }
}

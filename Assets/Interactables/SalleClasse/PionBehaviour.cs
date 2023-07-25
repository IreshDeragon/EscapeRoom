using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionBehaviour : MonoBehaviour
{
    public enum pions
    {
        Rouge,
        Vert,
        Bleu,
        Jaune
    }
    public pions Couleur;
    public bool grabbed;

    //sons
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance placeEvent;

    private void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleClassroom/IG_PC_take_figurine");
        placeEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleClassroom/IG_PC_pose_figurine_on_model_correctly");
    }

    public void setgrabbed(bool grab)
    {
        grabbed = grab;
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
}

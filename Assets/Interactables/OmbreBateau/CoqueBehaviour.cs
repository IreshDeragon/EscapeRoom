using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoqueBehaviour : MonoBehaviour
{
    public bool BoneCoque;
    public GameObject voile;
    public bool grabbed;
    public bool isGood;

    //sons
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance placeEvent;
    private FMOD.Studio.EventInstance sailEvent;


    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBoat/IG_PB_take_boat_hull");
        placeEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBoat/IG_PB_place_boat_hull");
        sailEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBoat/IG_PB_good_boat_hull_on_shadow");
    }

    public void showVoile()
    {
        //voile.SetActive(true);
        isGood = true;
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
    public void placeSail()
    {
        sailEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        sailEvent.start();
    }
}

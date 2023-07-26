using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : MonoBehaviour
{
    public GameObject StrikePoint;
    public Collider colider;
    public bool grabbed;

    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;

    // Start is called before the first frame update
    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_take_hammer");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_pose_hammer");
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "decors")
        {
            fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            fallEvent.start();
        }
    }
    public void setGrabbed(bool grab)
    {
        grabbed = grab;
    }

    public void pickSound()
    {
        pickEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pickEvent.start();
    }
}

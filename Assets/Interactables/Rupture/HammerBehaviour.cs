using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : MonoBehaviour
{
    public GameObject StrikePoint;
    public Collider colider;
    public bool grabbed;

    private FMOD.Studio.EventInstance pickEvent;

    // Start is called before the first frame update
    void Start()
    {
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_take_hammer");
    }

    // Update is called once per frame
    void Update()
    {
        
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

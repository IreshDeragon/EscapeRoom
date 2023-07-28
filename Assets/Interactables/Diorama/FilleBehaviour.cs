using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FilleBehaviour : MonoBehaviour
{
    public PlayableDirector director;

    private FMOD.Studio.EventInstance cryEvent;
    float timer = 0;
    bool cryLaunched = false;
    bool playCry = true;
    void Start()
    {
        cryEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Animations/PuzzleFinalModel/A_PFM_crying_Maggie");
        
        /*director.Play();
        timer = (float)director.duration;*/
    }
    void Update()
    {
        if (!cryLaunched)
        {
            cryEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            cryEvent.start();
            cryLaunched = true;
        }

        /*timer -= Time.deltaTime;
        if(timer <= 0)
        {
            director.Play();
            timer = (float)director.duration;
        }*/
        if (playCry)
            director.Play();
        else
            cryEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void setPlayCry(bool bo)
    {
        playCry = bo;
    }
}

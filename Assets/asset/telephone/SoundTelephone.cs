using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTelephone : MonoBehaviour
{
    private FMOD.Studio.EventInstance ringEvent;
    private FMOD.Studio.EventInstance concourEvent;
    private FMOD.Studio.EventInstance pingEvent;
    float timer;
    bool ringStoped = false;
    bool messagePlayed = false;
    bool ringBegan = false;
    // Start is called before the first frame update
    void Start()
    {
        ringEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/Common/IG_C_ring_phone");
        concourEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/Common/IG_C_listen_voice_message");
        pingEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/Common/IG_C_use_phone");

        

    }

    // Update is called once per frame
    void Update()
    {
        if (!ringBegan)
        {
            ringEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            ringEvent.start();
            
            ringBegan = true;
        }
        timer += Time.deltaTime;
        if(!ringStoped && timer >= 6.5)
        {
            ringEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            ringStoped = true;

            pingEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            pingEvent.start();
        }
        if(!messagePlayed && timer >= 7f)
        {
            concourEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            concourEvent.start();
            messagePlayed = true;
        }
    }
}

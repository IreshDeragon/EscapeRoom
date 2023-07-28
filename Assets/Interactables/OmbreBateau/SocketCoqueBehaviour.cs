using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SocketCoqueBehaviour : MonoBehaviour
{
    public bool BonCoque = false;
    public bool grabbed;
    public float time;
    public float rotationMin;
    public float rotationMax;
    public Transform parentTransform;
    public GameObject voile;
    public PlayableDirector director;
    public GameObject boutJournal;

    bool completed = false;

    //sons
    private FMOD.Studio.EventInstance correctEvent;

    public GameObject CoqueIn;
    // Start is called before the first frame update
    void Start()
    {
        correctEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleBoat/IG_PB_good_boat_hull_on_shadow");
    }

    // Update is called once per frame
    void Update()
    {
        if(BonCoque && !grabbed && !completed)
        {
            if(parentTransform.rotation.eulerAngles.y >= rotationMin && parentTransform.rotation.eulerAngles.y <= rotationMax)
            {
                CoqueIn.GetComponent<CoqueBehaviour>().showVoile();
                voile.GetComponent<Rigidbody>().isKinematic = false;
                voile.GetComponent<Rigidbody>().useGravity = true; 
                boutJournal.GetComponent<Rigidbody>().isKinematic = false;
                boutJournal.GetComponent<Rigidbody>().useGravity = true;
                correctEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
                correctEvent.start();
                voile.transform.GetChild(0).gameObject.SetActive(true);
                boutJournal.transform.GetChild(0).gameObject.SetActive(true);
                completed = true;
                director.Play();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (!completed)
        {
            //GameObject parent = other.GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<Transform>().gameObject;
            GameObject parent = other.gameObject.transform.parent.transform.parent.gameObject;
            if (parent.GetComponent<CoqueBehaviour>() != null)
            {
                if (!parent.GetComponent<CoqueBehaviour>().grabbed)
                {
                    if (parent.GetComponent<CoqueBehaviour>().BoneCoque == true)
                    {
                        BonCoque = true;
                    }
                    CoqueIn = parent;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject parent = other.gameObject.transform.parent.transform.parent.gameObject;
        if (parent == CoqueIn)
        {
            BonCoque = false;
        }
    }

    public void setgrabbed(bool grab)
    {
        grabbed = grab;
    }

}

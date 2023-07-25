using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class SchoolManager : MonoBehaviour
{
    public GameObject[] sockets;
    public bool completed = false;
    public GameObject locket;
    public GameObject tiroirHandGrab;
    public GameObject[] unlockObjects;

    public PlayableDirector director;

    //son
    private FMOD.Studio.EventInstance correctEvent;

    // Start is called before the first frame update
    void Start()
    {
        correctEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleClassroom/IG_PC_resolved");
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            completed = testCombinaison();
            if (completed)
            {
                resolution();
            }
        }
    }

    bool testCombinaison()
    {
        bool res = true;
        foreach(GameObject socket in sockets)
        {
            if (!socket.GetComponent<SocketPionBehaviour>().goodAnswer())
            {
                res = false;
            }
        }
        
        return res;
    }
    void resolution()
    {
        foreach (GameObject socket in sockets) //on désactive l'utilisation des pions
        {
            GameObject pion = socket.GetComponent<SocketPionBehaviour>().getPionPlaced();
            pion.transform.GetChild(2).gameObject.GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractable>().enabled = false;
        }

        //Ouvrir le tiroir
        correctEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        correctEvent.start();
        director.Play();
        unlockGameObjects();
        tiroirHandGrab.SetActive(true);
    }


    void unlockGameObjects()
    {
        foreach (GameObject obj in unlockObjects)
        {
            obj.transform.GetChild(0).gameObject.SetActive(true);
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}

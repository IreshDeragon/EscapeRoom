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

    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        
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
        director.Play();
        tiroirHandGrab.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SchoolManager : MonoBehaviour
{
    public GameObject[] sockets;
    bool completed = false;
    public GameObject locket;

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
        foreach (GameObject socket in sockets)
        {
            socket.GetComponent<SocketPionBehaviour>().getPionPlaced().GetComponent<Oculus.Interaction.Grabbable>().enabled = false;
            socket.SetActive(false);//a tester, ça ne m'a pas l'air terrible
        }

        //Ouvrir le tiroir
        Quaternion target = locket.transform.rotation;
        target.x += 90;
        Quaternion.Lerp(locket.transform.rotation, target, 1f);
    }
}

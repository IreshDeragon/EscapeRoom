using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketPionBehaviour : MonoBehaviour
{

    public PionBehaviour.pions Couleur;

    public bool BonPion =false;

    public GameObject pionIn;

    public bool grabbed;


    private void OnTriggerStay(Collider other)
    {
        //GameObject parent = other.GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<Transform>().gameObject;
        GameObject parent = other.gameObject.transform.parent.transform.parent.transform.parent.gameObject;
        if (parent.GetComponent<PionBehaviour>()!= null)
        {
            if (!parent.GetComponent<PionBehaviour>().grabbed)
            {
            if (parent.GetComponent<PionBehaviour>().Couleur == Couleur)
                {
                    BonPion = true;
                }
                pionIn = parent;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject parent = other.gameObject.transform.parent.transform.parent.transform.parent.gameObject;
        if (parent == pionIn)
        {
            BonPion = false;
        }
    }

    public GameObject getPionPlaced()
    {
        return pionIn;
    }
    public bool goodAnswer()
    {
        return BonPion;
    }
    public void setgrabbed(bool grab)
    {
        grabbed = grab;
    }
}

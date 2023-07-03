using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketPionBehaviour : MonoBehaviour
{

    public PionBehaviour.pions Couleur;

    bool BonPion =false;

    Collider pionIn;


    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<PionBehaviour>()!= null)
        {
            if (!other.GetComponent<PionBehaviour>().grabbed)
            {
                if (other.GetComponent<PionBehaviour>().Couleur == Couleur)
                {
                    BonPion = true;
                }
                pionIn = other;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other == pionIn)
        {
            BonPion = false;
        }
    }

    public Collider getPionPlaced()
    {
        return pionIn;
    }
    public bool goodAnswer()
    {
        return BonPion;
    }
}

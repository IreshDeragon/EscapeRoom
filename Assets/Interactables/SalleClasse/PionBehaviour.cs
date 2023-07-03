using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionBehaviour : MonoBehaviour
{
    public enum pions
    {
        Rouge,
        Vert,
        Bleu,
        Jaune
    }
    public pions Couleur;
    public bool grabbed;
    public void setgrabbed(bool grab)
    {
        grabbed = grab;
    }
}

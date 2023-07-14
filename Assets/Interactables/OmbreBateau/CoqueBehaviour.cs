using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoqueBehaviour : MonoBehaviour
{
    public bool BoneCoque;
    public GameObject voile;
    public bool grabbed;
    public bool isGood;
    // Start is called before the first frame update

    public void showVoile()
    {
        voile.SetActive(true);
        isGood = true;
    }
    public void setgrabbed(bool grab)
    {
        grabbed = grab;
    }
}

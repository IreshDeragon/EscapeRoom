using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject handGrab;
    public GameObject handGrabMirror;

    public void disableGrab()
    {
        handGrab.SetActive(false);
        handGrabMirror.SetActive(false);
    }
}

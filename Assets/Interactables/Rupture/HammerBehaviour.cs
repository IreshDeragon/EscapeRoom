using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBehaviour : MonoBehaviour
{
    public GameObject StrikePoint;
    public Collider colider;
    public bool grabbed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setGrabbed(bool grab)
    {
        grabbed = grab;
    }
}

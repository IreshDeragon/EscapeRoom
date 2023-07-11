using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoqueBehaviour : MonoBehaviour
{
    bool snapped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setOneGrabTransformerFreeGrab()
    {
        Oculus.Interaction.ITransformer freeGrab =  transform.GetComponent<Oculus.Interaction.OneGrabFreeTransformer>();
        transform.GetComponent<Oculus.Interaction.Grabbable>().InjectOptionalOneGrabTransformer(freeGrab);
    }
    public void setOneGrabTranformerPhysicsGrab()
    {
        Oculus.Interaction.ITransformer PhysicsGrab = transform.GetComponent<Oculus.Interaction.OneGrabPhysicsJointTransformer>();
        transform.GetComponent<Oculus.Interaction.Grabbable>().InjectOptionalOneGrabTransformer(PhysicsGrab);
    }
    public void setSnapped(bool snap)
    {
        snapped = snap;
    }
}

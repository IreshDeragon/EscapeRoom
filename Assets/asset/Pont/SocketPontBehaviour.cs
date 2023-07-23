using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketPontBehaviour : MonoBehaviour
{
    public GameObject Pont;
    
    public void MakeChild()
    {
        Destroy(Pont.GetComponent<Rigidbody>());
        Pont.GetComponent<MeshCollider>().enabled = false;
        Pont.GetComponent<Oculus.Interaction.Grabbable>().enabled = false;
        Pont.transform.parent = transform;
    }
}

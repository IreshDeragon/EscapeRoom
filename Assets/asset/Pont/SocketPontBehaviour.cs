using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketPontBehaviour : MonoBehaviour
{
    public GameObject Pont;
    
    public void MakeChild()
    {
        //Pont.transform.parent = transform.parent;
        MeshCollider[] newMeshes = Pont.GetComponent<PontParentBehaviour>().setParent(transform.parent.gameObject);
        transform.parent.GetComponent<PontParentBehaviour>().activateMeshes(newMeshes);
        transform.parent.GetComponent<PontSound>().assembleSound();
    }
}

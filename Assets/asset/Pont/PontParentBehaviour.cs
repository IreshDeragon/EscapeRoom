using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontParentBehaviour : MonoBehaviour
{
    public GameObject Parent;
    public MeshCollider[] activeMesh;
    public Transform positionPanneau;

    private void Start()
    {
        Parent = gameObject;
    }


    public MeshCollider[] setParent(GameObject parent)
    {
        if(Parent == gameObject)
        {
            //Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //gameObject.GetComponent<Oculus.Interaction.Grabbable>().enabled = false;
            //gameObject.GetComponent<MeshCollider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);

            Parent.transform.parent = parent.transform;
            Parent = parent;
            return activeMesh;
        }
        else
        {
            return Parent.GetComponent<PontParentBehaviour>().setParent(parent);
        }
        
    }
    public void activateMeshes(MeshCollider[] meshes)
    {
        if(Parent == gameObject)
        {
            int i = 0;
            foreach (MeshCollider mesh in meshes)
            {
                if (mesh.enabled == true)
                {
                    activeMesh[i].enabled = true;
                    //mesh.enabled = false;
                }
                ++i;
            }
            meshes[0].transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Parent.GetComponent<PontParentBehaviour>().activateMeshes(meshes);
        }

        testReussite();
        
    }


    private void testReussite()
    {
        if (Parent == gameObject)
        {
            bool res = true;
            foreach(MeshCollider mesh in activeMesh)
            {
                if (!mesh.enabled)
                {
                    res = false;
                }
            }

            if (res)
            {
                transform.parent.GetComponent<PontBehaviour>().completed(activeMesh[2].transform , positionPanneau);
            }
        }
    }
}

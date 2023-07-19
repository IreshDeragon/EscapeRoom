using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChestBehaviour : MonoBehaviour
{
    public GameObject key;
    public GameObject grab;
    public GameObject grabMiror;
    public GameObject[] coques;
    // Start is called before the first frame update
    public void openChest()
    {
        key.GetComponent<Rigidbody>().isKinematic = true;
        key.GetComponent<Rigidbody>().useGravity = false;
        key.GetComponent<KeyBehaviour>().disableGrab();
        grab.SetActive(true);
        grabMiror.SetActive(true);
        transform.GetComponent<MeshCollider>().enabled = true;
        transform.GetComponent<BoxCollider>().enabled = true;

        foreach(GameObject coque in coques)
        {
            coque.GetComponent<Rigidbody>().isKinematic = false;
            coque.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}

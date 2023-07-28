using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KeyChestBehaviour : MonoBehaviour
{
    public GameObject key;
    public GameObject grab;
    public GameObject grabMiror;
    public GameObject[] objetsActiver;

    public PlayableDirector director;
    // Start is called before the first frame update
    public void openChest()
    {
        //key.GetComponent<Rigidbody>().isKinematic = true;
        //key.GetComponent<Rigidbody>().useGravity = false;
        //key.GetComponent<KeyBehaviour>().disableGrab();
        grab.SetActive(true);
        grabMiror.SetActive(true);
        transform.GetComponent<MeshCollider>().enabled = true;
        transform.GetComponent<BoxCollider>().enabled = true;
        director.Play();

        foreach (GameObject obj in objetsActiver)
        {
            obj.GetComponent<Rigidbody>().isKinematic = false;
            obj.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCoqueBehaviour : MonoBehaviour
{
    public bool BonCoque = false;
    public bool grabbed;
    public float time;
    public float rotationMin;
    public float rotationMax;
    public Transform parentTransform;

    public GameObject CoqueIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BonCoque && !grabbed)
        {
            if(parentTransform.rotation.eulerAngles.y >= rotationMin && parentTransform.rotation.eulerAngles.y <= rotationMax)
            {
                CoqueIn.GetComponent<CoqueBehaviour>().showVoile();
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        //GameObject parent = other.GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<Transform>().gameObject;
        GameObject parent = other.gameObject.transform.parent.transform.parent.gameObject;
        if (parent.GetComponent<CoqueBehaviour>() != null)
        {
            if (!parent.GetComponent<CoqueBehaviour>().grabbed)
            {
                if (parent.GetComponent<CoqueBehaviour>().BoneCoque == true)
                {
                    BonCoque = true;
                }
                CoqueIn = parent;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject parent = other.gameObject.transform.parent.transform.parent.gameObject;
        if (parent == CoqueIn)
        {
            BonCoque = false;
        }
    }

    public void setgrabbed(bool grab)
    {
        grabbed = grab;
    }
}

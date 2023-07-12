using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenaRoueBehaviour : MonoBehaviour
{
    public int value;
    public float rotationSpeed;
    Vector3 direction = new Vector3(0f, 0f, 1f);
    Transform child;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (child.rotation.eulerAngles.z < (value)*40 -0.5 || child.rotation.eulerAngles.z > (value) * 40 + 0.5)
        {
            child.Rotate(direction * rotationSpeed * Time.deltaTime);
        }
    }
    
    public void incrementValue()
    {
        value = (value + 1)%9;
    }
}

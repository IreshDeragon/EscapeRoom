using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenaRoueBehaviour : MonoBehaviour
{
    public int value;
    public float rotationSpeed;
    Vector3 direction = new Vector3(0f, 0f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.eulerAngles.z < (value)*40 -0.5 || transform.rotation.eulerAngles.z > (value) * 40 + 0.5)
        {
            transform.Rotate(direction * rotationSpeed * Time.deltaTime);
        }
    }

    public void incrementValue()
    {
        value = (value + 1)%9;
    }
}

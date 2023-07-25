using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenaRoueBehaviour : MonoBehaviour
{
    public int value;
    public float rotationSpeed;
    Vector3 direction = new Vector3(0f, 0f, 1f);
    Transform child;
    private FMOD.Studio.EventInstance clicEvent;

    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0);
        clicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_enter_padlock_code");
    }

    // Update is called once per frame
    void Update()
    {
        if (child.rotation.eulerAngles.z < (value)*40 -0.5 || (child.rotation.eulerAngles.z > (value) * 40 + 0.5 && value ==0))
        {
            child.Rotate(direction * rotationSpeed * Time.deltaTime);
        }
    }
    
    public void incrementValue()
    {
        value = (value + 1)%9;
        clicEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        clicEvent.start();
    }
}

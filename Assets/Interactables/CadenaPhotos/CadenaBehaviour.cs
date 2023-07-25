using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenaBehaviour : MonoBehaviour
{
    public int premierChiffre;
    public int secondChiffre;
    public int troisiemeChiffre;
    public int[] Solution= new int[3];
    public GameObject porte;
    public GameObject handGrab;
    public GameObject handGrabMirror;
    public GameObject[] objetsDeverouille;
    bool completed = false;

    //sons
    private FMOD.Studio.EventInstance grabDoorEvent;

    // Start is called before the first frame update
    void Start()
    {
        grabDoorEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzlePictures/IG_PP_open_padlock");
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            if (premierChiffre == Solution[0] && secondChiffre == Solution[1] && troisiemeChiffre == Solution[2])
            {
                porte.transform.GetComponent<Oculus.Interaction.Grabbable>().enabled = true;
                handGrab.GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractable>().enabled = true;
                handGrabMirror.GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractable>().enabled = true;
                completed = true;
                foreach(GameObject obj in objetsDeverouille)
                {
                    obj.GetComponent<Rigidbody>().isKinematic = false;
                    Oculus.Interaction.HandGrab.HandGrabInteractable[] components = obj.GetComponentsInChildren<Oculus.Interaction.HandGrab.HandGrabInteractable>();
                    foreach(Oculus.Interaction.HandGrab.HandGrabInteractable comp in components)
                    {
                        comp.enabled = true;
                    }
                }
            }
        }
    }
    public void setCliqued(int clic)
    {
        switch (clic)
        {
            case 0:
                premierChiffre = (premierChiffre + 1) % 9;
                break;
            case 1:
                secondChiffre = (secondChiffre + 1) % 9;
                break;
            case 2:
                troisiemeChiffre = (troisiemeChiffre + 1) % 9;
                break;
        }
    }


    //Sons
    public void grabDoorSound()
    {
        grabDoorEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.GetChild(0).gameObject));
        grabDoorEvent.start();
    }

}

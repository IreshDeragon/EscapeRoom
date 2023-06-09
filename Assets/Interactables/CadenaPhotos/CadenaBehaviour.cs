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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(premierChiffre == Solution[0] && secondChiffre == Solution[1] && troisiemeChiffre == Solution[2])
        {
            porte.transform.GetComponent<Oculus.Interaction.Grabbable>().enabled = true;
            handGrab.SetActive(true);
            handGrabMirror.SetActive(true);
        }
    }
    public void setCliqued(int clic)
    {
        switch (clic)
        {
            case 1:
                premierChiffre = (premierChiffre + 1) % 9;
                break;
            case 2:
                secondChiffre = (secondChiffre + 1) % 9;
                break;
            case 3:
                troisiemeChiffre = (troisiemeChiffre + 1) % 9;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PontBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pontFini;
    public GameObject panneau;
    public PlayableDirector director;
    public GameObject diorama;

    public void completed(Transform transPont, Transform transPanneau)
    {
        pontFini.GetComponent<PontFiniBehaviour>().spawn(transPont);
        diorama.GetComponent<DioramaBehaviour>().setObjectToDestroy(11 ,Instantiate(panneau, transPanneau.position, transPanneau.rotation));
        
        Destroy(gameObject);
    }
}

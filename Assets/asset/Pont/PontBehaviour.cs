using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PontBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PrefabFini;
    public PlayableDirector director;

    public void completed(Transform trans)
    {
        trans.Rotate(new Vector3(89, 0, 0));
        GameObject pont = Instantiate(PrefabFini, trans.position, trans.rotation);
        pont.GetComponent<PontFiniBehaviour>().director = director;
        Destroy(gameObject);
    }
}

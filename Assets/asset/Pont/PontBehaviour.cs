using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PrefabFini;

    public void completed(Transform trans)
    {
        trans.Rotate(new Vector3(89, 0, 0));
        Instantiate(PrefabFini, trans.position, trans.rotation);
        Destroy(gameObject);
    }
}

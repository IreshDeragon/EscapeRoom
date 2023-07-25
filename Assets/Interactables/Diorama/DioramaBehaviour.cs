using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaBehaviour : MonoBehaviour
{
    public GameObject songes;
    public Material m_allume;
    public bool completed;
    public float timer;
    bool completionDone = false;

    bool[] validation = new bool[6];
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<6; i++)
        {
            validation[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            timer -= Time.deltaTime;
        }
    }

    public void validateSocket(int nbSocket)
    {
        songes.transform.GetChild(nbSocket).GetComponent<MeshRenderer>().material = m_allume;
        validation[nbSocket] = true;

        bool res = false;
        for (int i = 0; i < 6; i++)
        {
            if (!validation[i])
            {
                res = false;
            }
        }
        if (res)
        {
            completed = true;
            completionDiorama();
        }
    }

    void completionDiorama()
    {
        //validation du diorama
        if(timer <= 0)
        {

        }
        else
        {

        }
    }
}

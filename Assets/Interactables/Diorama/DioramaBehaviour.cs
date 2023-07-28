using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DioramaBehaviour : MonoBehaviour
{
    public GameObject songes;
    public GameObject Fille;
    public Material m_allume;
    public GameObject countDownTimer;

    public GameObject otherDiorama;
    public GameObject[] objectToDestroy;
    public PlayableDirector directorDiorama;
    public Renderer M_otherDiorama;


    public GameObject maquettePereFilleCassee;
    public PlayableDirector directorCasser;
    public Transform Statuette;

    public float timeAnimDiorama;
    public float timeBeforeJeffAcceptationOrNot;

    public int phase = 0;

    public float timer;

    public bool[] validation = new bool[6];
    
    void Start()
    {
        for(int i =0; i<6; i++)
        {
            validation[i] = false;
        }
        //timer = 0;//pour le test
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 0:
                timer -= Time.deltaTime;
                break;
            case 1:
                otherDiorama.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
                foreach(GameObject obj in objectToDestroy)
                {
                    Destroy(obj);
                }
                directorDiorama.Play();
                phase = 2;
                break;
            case 2:
                timeAnimDiorama -= Time.deltaTime;

                M_otherDiorama.material.SetFloat("_WichOne", getMaterialValue(timeAnimDiorama, 12f, 2f)); //change le material du diorama
                if (timeAnimDiorama <= 0)
                {
                    phase = 3;
                }
                break;
            case 3:
                Fille.SetActive(true);
                phase = 4;
                break;
            case 4:
                timeBeforeJeffAcceptationOrNot -= Time.deltaTime;
                if (timeBeforeJeffAcceptationOrNot <= 0)
                {
                    phase = 5;
                }
                break;
            case 5:
                completionDioramaAlternateEnd();
                phase = 6;
                break;
        }
    }

    public void validateSocket(int nbSocket)
    {
        songes.transform.GetChild(nbSocket).GetComponent<MeshRenderer>().material = m_allume;
        validation[nbSocket] = true;

        bool res = true;
        for (int i = 0; i < 6; i++)
        {
            if (!validation[i])
            {
                res = false;
            }
        }
        if (res)
        {
            phase = 1;
            countDownTimer.GetComponent<CountdownTimer>().setStoped(true);
        }
    }

    float getMaterialValue(float timer, float maxTimer, float minTimer)
    {
        float res = 1-((timer - minTimer) / (maxTimer - minTimer));
        if(res >= 1)
        {
            res = 1;
        }
        if (res <= 0)
        {
            res = 0;
        }
        return res;
    }

    void completionDioramaAlternateEnd()
    {
        if(timer <= 0)
        {
            //son non non c'est impossible
            maquettePereFilleCassee.transform.position = new Vector3(0, 0, 0);
            Destroy(Statuette.gameObject);
            directorCasser.Play();
        }
        else
        {
            Statuette.GetChild(0).gameObject.SetActive(true);
            Statuette.gameObject.layer = 3;
        }
    }


    public void setObjectToDestroy(int index, GameObject obj)
    {
        objectToDestroy[index] = obj;
    }
}

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
                
                //faire l'anim du diorama
                phase = 2;
                break;
            case 2:
                timeAnimDiorama -= Time.deltaTime;
                if (timeAnimDiorama <= 0)
                {
                    phase = 3;
                }
                break;
            case 3:
                timeBeforeJeffAcceptationOrNot -= Time.deltaTime;
                if (timeBeforeJeffAcceptationOrNot <= 0)
                {
                    phase = 4;
                }
                break;
            case 4:
                completionDioramaAlternateEnd();
                phase = 5;
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

            Fille.SetActive(true);
            countDownTimer.GetComponent<CountdownTimer>().setStoped(true);
        }
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
        }
    }
}

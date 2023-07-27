using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HeartBehaviour : MonoBehaviour
{
    public float distanceTreshold = 0.94f;
    public int nbcoup;
    public float timerCoups;
    public GameObject point;
    float proximite;

    public GameObject diorama;

    public GameObject Hammer;
    public GameObject Heart;
    public Collider heartCollider;
    public bool grabbed = false;
    public GameObject keyPrefab;
    public GameObject rocherPrefab;
    public GameObject fragmentPrefab;
    public PlayableDirector director;
    public PlayableDirector batementCoeur;

    int cptCoup = 0;
    float timer;
    bool hasbeen = false;
    float timerBatement = 0;
    bool completed = false;

    //sons
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerCoups;

        //init sons
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_take_stone_heart");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_pose_stone_heart");
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            if (cptCoup > 0)
            {
                timer += Time.deltaTime;
                if (timer > timerCoups)
                {
                    nbcoup = 0;
                    timer = 0;
                }
            }

            if (grabbed && Hammer.GetComponent<HammerBehaviour>().grabbed)
            {
                if (CheckCollision(Heart, Hammer.GetComponent<HammerBehaviour>().colider))
                {
                    if (!hasbeen)
                    {
                        OnCollisionEnterInteraction(Hammer);
                        hasbeen = true;
                    }
                }
                else
                {
                    Debug.Log("NON ");
                    hasbeen = false;
                }
            }
            else
            {
                hasbeen = false;
            }
        }
        else
        {
            timerBatement += Time.deltaTime;
            if(timerBatement >= 3.6f)
            {
                Instantiate(keyPrefab, transform.position, transform.rotation);
                diorama.GetComponent<DioramaBehaviour>().setObjectToDestroy(12 ,Instantiate(rocherPrefab, transform.position, transform.rotation));
                GameObject frag = Instantiate(fragmentPrefab, transform.position, transform.rotation);
                frag.GetComponent<BrokentHeartBehaviour>().director = director;
                Destroy(gameObject);
            }
        }
    }

    public void setGrabbed(bool grab)
    {
        grabbed = grab;
    }
    private bool CheckCollision(GameObject obj1, Collider obj2Collider)
    {
        Collider[] cols = Physics.OverlapSphere(Hammer.GetComponent<HammerBehaviour>().StrikePoint.transform.position, 0.01f);
        bool collisionDetected = false;
        //collisionDetected = heartCollider.bounds.Intersects(obj2Collider.bounds);

        foreach(Collider col in cols)
        {
            if(col == heartCollider)
            {
                collisionDetected = true;
                //o
            }
        }

        return collisionDetected;
    }
    private void OnCollisionEnterInteraction(GameObject leftObject)
    {
        GameObject strikeZone = leftObject.gameObject.GetComponent<HammerBehaviour>().StrikePoint;
        proximite = 1 - Vector3.Distance(point.transform.position, strikeZone.transform.position); //calcul de la distance entre le bout du marteau et le point

        //Je clamp la valeur entre 0 et 1 pour ne pas avoir d'erreurs dans fmod
        if (proximite < 0)
        {
            proximite = 0.0f;
        }
        if (proximite > 1)
        {
            proximite = 1.0f;
        }
        Debug.Log("Proximité : " + proximite);
        strike();
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "hammer")
        {
            GameObject strikeZone = col.gameObject.GetComponent<HammerBehaviour>().StrikePoint;
            proximite = 1 - Vector3.Distance(point.transform.position, strikeZone.transform.position); //calcul de la distance entre le bout du marteau et le point

            //Je clamp la valeur entre 0 et 1 pour ne pas avoir d'erreurs dans fmod
            if (proximite < 0 )
            {
                proximite = 0.0f;
            }
            if(proximite > 1)
            {
                proximite = 1.0f;
            }
            Debug.Log("Proximité : " + proximite);
            strike();
        }
        else if(col.gameObject.tag == "decors")
        {
            fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            fallEvent.start();
        }
    }


    void strike()
    {
        if(proximite>= distanceTreshold)
        {
            ++cptCoup;
            timer = 0;
        }
        if(cptCoup >= nbcoup)
        {
            breakHeart();
        }
    }
    void breakHeart()
    {
        completed = true;
        batementCoeur.Play();
    }


    /*
     * Sons
     */
    public void pickSound()
    {
        pickEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        pickEvent.start();
    }
}

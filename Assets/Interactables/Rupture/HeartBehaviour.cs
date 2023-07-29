using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HeartBehaviour : MonoBehaviour
{
    public float distanceTreshold = 0.96f;
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
    float hasbeen = 0;
    float timerBatement = 0;
    bool completed = false;

    //sons
    private FMOD.Studio.EventInstance pickEvent;
    private FMOD.Studio.EventInstance fallEvent;
    private FMOD.Studio.EventInstance strikeEvent;


    // Start is called before the first frame update
    void Start()
    {
        timer = timerCoups;

        //init sons
        pickEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_take_stone_heart");
        fallEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_pose_stone_heart");
        strikeEvent = FMODUnity.RuntimeManager.CreateInstance("event:/InGame/PuzzleStoneHeart/IG_PSH_striking_stone_heart");
    }

    // Update is called once per frame
    void Update()
    {
        if (!completed)
        {
            if(hasbeen >= 0)
            {
                hasbeen -= Time.deltaTime;
            }
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
                    if (hasbeen<=0)
                    {
                        OnCollisionEnterInteraction(Hammer);
                        hasbeen = 0.4f;
                    }
                }
            }
        }
        else
        {
            timerBatement += Time.deltaTime;
            if(timerBatement >= 6f)
            {
                GameObject key = Instantiate(keyPrefab, transform.position, transform.rotation);
                key.GetComponent<Respawn>().setRespawn(transform.GetComponent<Respawn>().getRespawn());
                GameObject rocher = Instantiate(rocherPrefab, transform.position, transform.rotation);
                diorama.GetComponent<DioramaBehaviour>().setObjectToDestroy(12 ,rocher);
                rocher.GetComponent<Respawn>().setRespawn(transform.GetComponent<Respawn>().getRespawn());
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
        Collider[] cols = Physics.OverlapSphere(Hammer.GetComponent<HammerBehaviour>().StrikePoint.transform.position, 0.0001f);
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

        Debug.Log("les transform" + point.transform.position + " et "+ strikeZone.transform.position);
        strike(proximite);
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "hammer")
        {
            /*GameObject strikeZone = col.gameObject.GetComponent<HammerBehaviour>().StrikePoint;
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
            strike(proximite);*/
        }
        else if(col.gameObject.tag == "decors")
        {
            fallEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
            fallEvent.start();
        }
    }


    void strike(float proximite)
    {
        float param = (proximite - 0.8f) * 5f;
        param = param > 1f ? 1f : param < 0f ? 0f : param;
        strikeEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        strikeEvent.setParameterByName("BreakPoint", param);
        strikeEvent.start();
        if (proximite>= distanceTreshold)
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

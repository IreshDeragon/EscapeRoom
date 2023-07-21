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

    public GameObject Hammer;
    public GameObject Heart;
    public Collider heartCollider;
    public bool grabbed = false;
    public GameObject keyPrefab;
    public GameObject rocherPrefab;
    public GameObject fragmentPrefab;
    public PlayableDirector director;

    int cptCoup = 0;
    float timer;
    bool hasbeen = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerCoups;
    }

    // Update is called once per frame
    void Update()
    {
        if (cptCoup > 0)
        {
            timer += Time.deltaTime;
            if(timer> timerCoups)
            {
                nbcoup = 0;
                timer = 0;
            }
        }

        if(grabbed && Hammer.GetComponent<HammerBehaviour>().grabbed)
        {
            if(CheckCollision(Heart, Hammer.GetComponent<HammerBehaviour>().colider))
            {
                if (!hasbeen)
                {
                    OnCollisionEnterInteraction(Hammer);
                    hasbeen = true;
                }
            }
            else
            {
                hasbeen = false;
            }
        }
        else
        {
            hasbeen = false;
        }
    }

    public void setGrabbed(bool grab)
    {
        grabbed = grab;
    }
    private bool CheckCollision(GameObject obj1, Collider obj2Collider)
    {
        // Vérifie s'il y a une collision entre les deux objets 
        //Collider obj1Collider = obj1.GetComponent<Collider>();
        //Collider obj2Collider = obj2.GetComponent<Collider>();

        // Utilisez la méthode appropriée pour vérifier la collision entre les colliders
        bool collisionDetected = heartCollider.bounds.Intersects(obj2Collider.bounds);

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
        Instantiate(keyPrefab, transform.position, transform.rotation);
        Instantiate(rocherPrefab, transform.position, transform.rotation);
        GameObject frag = Instantiate(fragmentPrefab, transform.position, transform.rotation);
        frag.GetComponent<BrokentHeartBehaviour>().director = director;
        Destroy(gameObject);
    }
}

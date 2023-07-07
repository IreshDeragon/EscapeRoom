using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    public float velocityTreshold = 1.0f;
    public float distanceTreshold = 0.94f;
    public GameObject point;
    float proximite;

    public GameObject Hammer;
    public GameObject Heart;
    public Collider heartCollider;
    public bool grabbed = false;


    bool hasbeen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        // V�rifie s'il y a une collision entre les deux objets 
        //Collider obj1Collider = obj1.GetComponent<Collider>();
        //Collider obj2Collider = obj2.GetComponent<Collider>();

        // Utilisez la m�thode appropri�e pour v�rifier la collision entre les colliders
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
        Debug.Log("Proximit� : " + proximite);
        Debug.Log("V�locit� : " + leftObject.GetComponent<Rigidbody>().velocity);
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
            Debug.Log("Proximit� : " + proximite);
            Debug.Log("V�locit� : " + col.rigidbody.velocity);

            //G�n�rer l'event fmod

            //G�n�rer une animation si d�truit

        }
    }
}

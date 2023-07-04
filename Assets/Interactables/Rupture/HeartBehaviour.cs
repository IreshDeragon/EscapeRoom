using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    public float velocityTreshold = 1.0f;
    public float distanceTreshold = 0.94f;
    public GameObject point;
    float proximite;

    public Transform leftHand;
    public Transform rightHand;
    private bool areObjectsGrabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (leftHand.childCount > 0 && rightHand.childCount > 0 && !areObjectsGrabbed)
        {
            // Vérifie si les deux objets sont tenus par les mains du joueur
            GameObject leftGrabbedObject = leftHand.GetChild(0).gameObject;
            GameObject rightGrabbedObject = rightHand.GetChild(0).gameObject;

            if (leftGrabbedObject != null && rightGrabbedObject != null)
            {
                areObjectsGrabbed = true;

                // Vérifie s'il y a une collision entre les objets
                if (CheckCollision(leftGrabbedObject, rightGrabbedObject))
                {
                    // Déclenche l'événement de collision ou effectue l'interaction souhaitée
                    OnCollisionEnterInteraction(leftGrabbedObject, rightGrabbedObject);
                }
            }
        }
        else if ((leftHand.childCount == 0 || rightHand.childCount == 0) && areObjectsGrabbed)
        {
            areObjectsGrabbed = false;
        }

    }

    private bool CheckCollision(GameObject obj1, GameObject obj2)
    {
        // Vérifie s'il y a une collision entre les deux objets 
        Collider obj1Collider = obj1.GetComponent<Collider>();
        Collider obj2Collider = obj2.GetComponent<Collider>();

        // Utilisez la méthode appropriée pour vérifier la collision entre les colliders
        bool collisionDetected = obj1Collider.bounds.Intersects(obj2Collider.bounds);

        return collisionDetected;
    }
    private void OnCollisionEnterInteraction(GameObject leftObject, GameObject rightObject)
    {
        // Faites quelque chose lorsque la collision se produit entre les deux objets
        Debug.Log("Collision detected between the grabbed objects: " + leftObject.name + " and " + rightObject.name);
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
            Debug.Log("Vélocité : " + col.rigidbody.velocity);

            //Générer l'event fmod

            //Générer une animation si détruit

        }
    }
}

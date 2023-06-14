using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour
{
    public float speed = 5.0f;
    public float intensity = 0.1f; //0.1
    public GameObject point;
    float proximite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.localPosition = intensity * new Vector3(
                Mathf.PerlinNoise(speed * Time.time, 1),
                Mathf.PerlinNoise(speed * Time.time, 2),
                Mathf.PerlinNoise(speed * Time.time, 3));*/

        

    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "hammer")
        {
            proximite = 1 - Vector3.Distance(point.transform.position, col.gameObject.transform.position);
            if (proximite < 0 )
            {
                proximite = 0.0f;
            }
            if(proximite > 1)
            {
                proximite = 1.0f;
            }
            Debug.Log(proximite);

            //Générer l'event fmod

            //Générer une animation?
             
            //Après avoir eu le marteau définir les zone max et min pour le son en fonction de la distance
        }
    }
}

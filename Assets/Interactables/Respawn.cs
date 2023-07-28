using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "respawn")
        {
            transform.position = respawnPoint.position;
        }
    }
    public void setRespawn(Transform trans)
    {
        respawnPoint = trans;
    }
    public Transform getRespawn()
    {
        return respawnPoint;
    }
}

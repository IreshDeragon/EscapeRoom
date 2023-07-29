using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public float timer;
    public bool goodEnd;
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Application.Quit();
        }
    }
    public void exit()
    {
        Application.Quit();
    }
    public void setEnd(bool isgood)
    {
        goodEnd = isgood;
    }
}

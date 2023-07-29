using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public float timer;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Application.Quit();
        }
    }
    public void exit()
    {
        Application.Quit();
    }
}

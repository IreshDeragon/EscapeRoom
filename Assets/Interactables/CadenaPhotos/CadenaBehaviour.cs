using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenaBehaviour : MonoBehaviour
{
    public int premierChiffre;
    public int secondChiffre;
    public int troisiemeChiffre;
    public int[] Solution= new int[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setCliqued(int clic)
    {
        switch (clic)
        {
            case 1:
                premierChiffre = (premierChiffre + 1) % 9;
                break;
            case 2:
                secondChiffre = (secondChiffre + 1) % 9;
                break;
            case 3:
                troisiemeChiffre = (troisiemeChiffre + 1) % 9;
                break;
        }
    }
}

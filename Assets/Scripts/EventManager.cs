using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static GameObject thePlayer;
    private Grid grid;
    private static bool passT;
    
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player");
        grid = GameObject.Find("Grid").GetComponent<Grid>();

    }

    // Update is called once per frame
    void Update()
    {
        if (passT)
        {
            StartCoroutine("PassTurn");
            passT = false;
        }
    }

    public static void LastAction()
    {

        thePlayer.GetComponent<CharControl>().canAct = true; 

        passT = true;

    }

    public  IEnumerator PassTurn()
    {
        yield return new WaitForSeconds(.1f);
        
        thePlayer.GetComponent<CharControl>().StartCoroutine("updateAct");
    }

    //a death control?
}

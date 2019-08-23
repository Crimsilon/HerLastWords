using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
    public static int currentActor = 0;

    public static int totalActors;
    private GameObject player;
    public static GameObject[] activeActors;

	// Use this for initialization
	void Start () {
        totalActors = 1;
        activeActors = buildList();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static  GameObject[] buildList()
    {
        try
        {
            return GameObject.FindGameObjectsWithTag("Enemy");
            
        }
        catch (System.Exception)
        {

            throw;
        }
      

    }

    //calls action on each of the slimes in the active actors array
    // Because the lack of an event manager class the method "the signal" comes from the slime class and signals the player can perform  an action again
    public static void round()
    {
        for(int i =0; i < activeActors.Length; i++)
        {
            activeActors[i].GetComponent<Slime>().action();

            //singles out the last Actor to act
            if (i == activeActors.Length - 1)
            {
                //tells this actor to notify the player so they can act again
                activeActors[i].GetComponent<Slime>().theSignal();
                
            }
        }
       
    }



    public static int getCurActor()
    {
        return currentActor;
    }

    public static void incrementActor()
    {
        currentActor = currentActor+1;
    }

    public static int getTotalActors()
    {
        return totalActors;
    }

    public static void lastActor()
    {
        if (currentActor == totalActors )
        {
            currentActor = 0;
        }
    }
  
}

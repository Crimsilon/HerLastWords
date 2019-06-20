using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
    public static int currentActor = 0;
    public static int totalActors;

	// Use this for initialization
	void Start () {
        totalActors = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour {
    public int actorNum = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (actorNum == TurnController.getCurActor())
        {
            action();
            TurnController.incrementActor();
            TurnController.lastActor();
        }
	}

    void action()
    {
        float act = Random.Range(0, 4);
        Vector3 temp = new Vector3(0,0,0);
        Debug.Log(act);
        if (act == 0)
        {
            Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
            newRotation = Quaternion.Euler(0, 180, 0); // this add a 180 degrees Y rotation
            transform.rotation = newRotation;
            temp = new Vector3(0, 0, -8);
        }
        if (act == 1)
        {
            Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
            newRotation = Quaternion.Euler(0, 0, 0); // this add a 0 degrees Y rotation
            transform.rotation = newRotation;
            temp = new Vector3(0, 0, 8);
        }
        if (act == 2)
        {
            Quaternion newRot = new Quaternion(0, 0, 0, 0);
            newRot = Quaternion.Euler(0, 270, 0);
            transform.rotation = newRot;
            temp = new Vector3(-8.0f, 0, 0);
        }
        if (act == 3)
        {
            Quaternion newRot = new Quaternion(0, 0, 0, 0);
            newRot = Quaternion.Euler(0, 0, 0);
            transform.rotation = newRot;
            temp = new Vector3(8.0f, 0, 0);
        }
       
        transform.position += temp;
    }
}

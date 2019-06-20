using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public int actorNum;
    private IEnumerator action;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
           if ( GameLoop.curActor()== actorNum)
           {
               action = act();

               StartCoroutine(action);
              // GameLoop.incrementActor();
           }
       }
       private IEnumerator act()
       {
           yield return new WaitForSeconds(2);
           Vector3 temp = new Vector3(1, 0, 0);
           transform.position += temp;
       }
       */
    }

}
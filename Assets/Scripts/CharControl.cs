using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CharControl : MonoBehaviour {
    public int actorNum = 1;
    public LayerMask unwalkableMask;
    public Vector3 playerPosition;
    private char choice;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
   
     
 
    
   // void action()
   // {
        void Update()
        {
        if (Input.anyKeyDown&& TurnController.getCurActor()==actorNum)
        {

           
            Debug.Log("action performed");
        }
        if (actorNum == TurnController.getCurActor())
        {
            if (Input.anyKeyDown)
            {
                
                action();
                Debug.Log(TurnController.getCurActor());
                Debug.Log("action performed");
                print(actorNum);
                TurnController.incrementActor();
                print(actorNum);
                TurnController.lastActor();
                print(actorNum);
            }

        }

            var forward = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            Debug.DrawRay(transform.position, forward, Color.blue);


            if (Physics.Raycast(transform.position, forward, out hit, 2))
            {
                Debug.Log("Hit");
            }

            // if(hit.collider.gameObject.name == "Test")
            // {
            //     Destroy(GetComponent("Rigidbody"));
            // }


        
        }
    void action()
    {


      

            //Move right increment x in positive
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.rotation.eulerAngles.y == 90)
                {
                
                Vector3 temp = new Vector3(8, 0, 0);
                Vector3 cast = transform.position += temp;
                if (Physics.CheckSphere(cast, 4))
                    {
                    print("help me");
                    temp = new Vector3(0, 0, 0);
                    }

                else
                {
                    
                }
                }
                else
                {
                    Quaternion temp = new Quaternion(0, 0, 0, 0);
                    temp = Quaternion.Euler(0, 90, 0);
                    transform.rotation = temp;

                }
            }

            // left
            if (Input.GetKeyDown(KeyCode.A))
            {

                if (transform.rotation.eulerAngles.y == 270)
                {
                    Vector3 temp = new Vector3(-8, 0, 0);
                    transform.position += temp;
                }
                else
                {
                    Quaternion temp = new Quaternion(0, 270, 0, 0);
                    temp = Quaternion.Euler(0, 270, 0);
                    transform.rotation = temp;
                }
            }

            // Move Up
            if (Input.GetKeyDown(KeyCode.W))
            {

                if (transform.rotation.eulerAngles.y == 0)
                {
                    Vector3 temp = new Vector3(0, 0, 8);
                    transform.position += temp;
                }
                else
                {

                    Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
                    newRotation = Quaternion.Euler(0, 0, 0); // this add a -90 degrees Y rotation
                    transform.rotation = newRotation;

                    //  Quaternion newRotation = Quaternion.AngleAxis(270, Vector3.up);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, .05f);
                }

            }


            //Move Backwards
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (transform.rotation.eulerAngles.y == 180)
                {
                    Vector3 temp = new Vector3(0, 0, -8);
                    transform.position += temp;
                }
                else
                {

                    Quaternion newRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w); ;
                    newRotation = Quaternion.Euler(0, 180, 0); // this add a 90 degrees Y rotation
                    transform.rotation = newRotation;

                }
            }

        }

    

}

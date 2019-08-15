        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;





        public class CharControl : MonoBehaviour {
            public int actorNum = 1;
            public LayerMask unwalkableMask;
            public Vector3 playerPosition;
            private char choice;
            public Vector3 destination;
            public Grid grid;
            public float smoothTime;
            private Vector3 velocity = Vector3.zero;

            // Use this for initialization
            void Start () {
		
	        }

            // Update is called once per frame




            // void action()
            // {

            private void Awake()
            {
        


            }
            void Update()
                {
                if (Input.anyKeyDown&& TurnController.getCurActor()==actorNum)
                {

           
                    //Debug.Log("action performed");
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

                    /*
                     *fooling around with raycasts to detect enemies infront of the player
                    var forward = transform.TransformDirection(Vector3.forward);
                    RaycastHit hit;
                    Debug.DrawRay(transform.position, forward, Color.blue);
            

                    if (Physics.Raycast(transform.position, forward, out hit, 2))
                    {
                        Debug.Log("Hit");
                    }
                    */

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
                            Vector3 destination = transform.position + temp;
                        //checking the grid square of the block up for vacancy
                            if (grid.NodeFromWorldPoint(destination).occupied())
                            {
                            //runs if unoccupied
                            Debug.Log("why");
                            //move isnt giving a smooth 
                            //StartCoroutine("Move");  
                        }
                            else
                            {
                            //runs movement if space is empty
                            Debug.Log("das");
                  
                            //transform.position = Vector3.MoveTowards(transform.position, destination, smoothTime * Time.deltaTime);

                            }

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


                    //Move Down
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
        
                IEnumerator Move()
                {
                print("s");
                    while (gameObject.transform.position != destination)
                    {
                        print(transform.position);
                        transform.position = Vector3.MoveTowards(transform.position, destination, smoothTime * Time.deltaTime);
                    }
                yield return null;
                }

                                                                                                                                                                                                                                

        }

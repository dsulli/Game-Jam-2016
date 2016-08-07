using UnityEngine;
using System.Collections;


public class BandKidController : BandController {

    public float moveSpeedX;
    public float moveSpeedY;
    
    public bool isGroup = false; //Keeps track if the member is within the group

    public enum Instrument { Trombone, Clarinet, Snare , Goat };
    public Sprite[] sprite;
    public Instrument instrumentType;
    public BoxCollider2D[] boxCol;


    public int row; //Keeps track of what row the member is in.
    int column; //Keeps track of what column the member is in.
    
   
	// Use this for initialization
	void Start () {
                
	
	}

    void Awake()
    {
        int type = Random.Range(0, 3);
        if (type == 0)
        {
            instrumentType = Instrument.Clarinet;
            GetComponent<SpriteRenderer>().sprite = sprite[0];
            boxCol[0].enabled = true;
        }
        else if (type == 1)
        {
            instrumentType = Instrument.Snare;
            GetComponent<SpriteRenderer>().sprite = sprite[1];
            boxCol[1].enabled = true;
        }
        else if (type == 2)
        {
            instrumentType = Instrument.Trombone;
            GetComponent<SpriteRenderer>().sprite = sprite[2];
            boxCol[2].enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        //Move left if they aren't part of the group
        if (!isGroup)
        {
            moveSpeedX = 2;
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            //Moves with the player from specific spot oriented around the player
            //moveSpeedX = 0;
            //moveSpeedY = 0;
            gameObject.transform.position = band[0,4].transform.position + new Vector3( 0.5f * column, 0.5f * (4 - row), -1 *row);

            //Moves with the player from where ever they attached from
            //moveSpeedX = Input.GetAxis("Horizontal") * band[0].GetComponent<CharacterController>().maxSpeed * 1f;
            //moveSpeedY = Input.GetAxis("Vertical") * band[0].GetComponent<CharacterController>().maxSpeed * 1f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeedX, moveSpeedY);
	
	}

    void attachToPlayer(GameObject player)
    {
        //If there are no other band members, attach to the Player
        //if(band[band.Count-1].tag == "Player")
        //{
            //gameObject.AddComponent<HingeJoint2D>();
            //GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            //gameObject.AddComponent<DistanceJoint2D>();
            //GetComponent<DistanceJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
            //GetComponent<DistanceJoint2D>().distance = 0.5f;
        
        
        //If it collided with the player, check to see if any of the rows are still empty, then put them into the player's row 
        if(player.tag == "Player")
        {
            if(band[0,3] == null)
            {
                band[0, 3] = gameObject;
                bandMembers++;
                row = 3;
                column = 0;
            }
            else if(band[0,5] == null)
            {
                band[0, 5] = gameObject;
                bandMembers++;
                row = 5;
                column = 0;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                
            }
            else if (band[0, 2] == null)
            {
                band[0, 2] = gameObject;
                bandMembers++;
                row = 2;
                column = 0;
            }
            else if (band[0, 6] == null)
            {
                band[0, 6] = gameObject;
                bandMembers++;
                row = 6;
                column = 0;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            else if (band[0, 1] == null)
            {
                band[0, 1] = gameObject;
                bandMembers++;
                row = 1;
                column = 0;
            }
            else if (band[0, 7] == null)
            {
                band[0, 7] = gameObject;
                bandMembers++;
                row = 7;
                column = 0;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            else if (band[0, 0] == null)
            {
                band[0, 0] = gameObject;
                bandMembers++;
                row = 0;
                column = 0;
            }
            else if (band[0, 8] == null)
            {
                band[0, 8] = gameObject;
                bandMembers++;
                row = 8;
                column = 0;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            else
            {
                bool filled = false;
                int counter = 1;
                //Keep running until an open spot is found
                while(!filled)
                { 
                    if(band[counter,4] == null)
                    {
                        band[counter, 4] = gameObject;
                        bandMembers++;
                        row = 4;
                        column = counter;
                        filled = true;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
        }//End Player check
        else
        {
            bool filled = false;
            int counter = 1;
            while(!filled)
            {
                if(band[counter, player.GetComponent<BandKidController>().row] == null)
                {
                    band[counter, player.GetComponent<BandKidController>().row] = gameObject;
                    bandMembers++;
                    row = player.GetComponent<BandKidController>().row;
                    column = counter;
                    filled = true;
                }
                else
                {
                    counter++;
                }
            }
        }


        isGroup = true;
        //band.Add(gameObject);

            
        //}


        //Attach to the band member at the end of the line
        //else if (band[band.Count-1] != null)
        //{
        //    //gameObject.AddComponent<HingeJoint2D>();
        //    //GetComponent<HingeJoint2D>().connectedBody = band[band.Count-1].GetComponent<Rigidbody2D>();
        //    gameObject.AddComponent<DistanceJoint2D>();
        //    GetComponent<DistanceJoint2D>().connectedBody = band[band.Count - 1].GetComponent<Rigidbody2D>();
        //    GetComponent<DistanceJoint2D>().distance = 0.75f;
        //    isGroup = true;
        //    band.Add(gameObject);
        //}
        
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player collides with the band kid and isn't already part of the group, attach them to the group
        if ((collision.gameObject.tag =="Player" || collision.gameObject.tag == "Bandkids") && !isGroup)
        {
            attachToPlayer(collision.gameObject);
           // collision.gameObject.GetComponent<CharacterController>().speedMultiplier = band.Count / 4;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player collides with the band kid and isn't already part of the group, attach them to the group
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bandkids") && !isGroup)
        {
            attachToPlayer(collision.gameObject);
            // collision.gameObject.GetComponent<CharacterController>().speedMultiplier = band.Count / 4;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bandkids")
        {
            Vector2 force = new Vector2(0.10f, 0.0f);
            collision.rigidbody.AddForce(force);
        }
    }


}

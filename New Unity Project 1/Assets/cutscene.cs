using UnityEngine;
using System.Collections;

public class cutscene : MonoBehaviour {
    private string[] lines;
    private string[] charID;
    GameObject keySprite;
    dialogManager dialogRef;
    private bool chatActive;


	// Use this for initialization
	void Start () {
        keySprite = transform.GetChild(0).gameObject;
        keySprite.SetActive(false);
        lines = new string[5];
        lines[0] = "Hi there my g";
        lines[1] = "Guess what we're doing";
        lines[2] = "OLD ENGLIISSSSH";
        lines[3] = "<id>2";
        lines[4] = "That shit is garbage my dude";

        charID = new string[2];
        charID[0] = "mike";
        charID[1] = "ike";
        dialogRef = dialogManager.Instance;
    }


    void Update()
    {
              
    }
    private void contactDialogManager()
    {
        dialogRef.loadText(lines);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        print(collision.gameObject.tag);
        /*
        if (collision.gameObject.tag == "Player")
        {
            keySprite.SetActive(true);
            if (Input.GetButton("Fire1"))
            {
                contactDialogManager();
            }
        }
        */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keySprite.SetActive(true);
            chatActive = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Fire1") && chatActive == false)
        {
            contactDialogManager();
            chatActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            keySprite.SetActive(false);
        }
    }
}


using UnityEngine;
using System.Collections;
using System.IO;

public class cutscene : MonoBehaviour {
    private string[] lines;
    private string[] charID;
    private speakingScript lines2;
    GameObject keySprite;
    dialogManager dialogRef;
    private bool chatActive;
    public string json;
    private string file = "somefile.txt";

	// Use this for initialization
	void Start () {
        keySprite = transform.GetChild(0).gameObject;
        keySprite.SetActive(false);
        lines2 = new speakingScript();
        lines2.lines = new string[5];
        lines2.lines[0] = "Hi there my g";
        lines2.lines[1] = "Guess what we're doing";
        lines2.lines[2] = "OLD ENGLIISSSSH";
        lines2.lines[3] = "<id>Capsule";
        lines2.lines[4] = "That shit is garbage my dude";

        charID = new string[2];
        charID[0] = "mike";
        charID[1] = "ike";
        dialogRef = dialogManager.Instance;
        lines2.length = lines2.lines.Length;
        json = JsonUtility.ToJson(lines2);
        print(json);
        File.WriteAllText(file, json);
    }


    void Update()
    {
              
    }
    private void contactDialogManager()
    {
        dialogRef.loadText(lines2.lines);
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


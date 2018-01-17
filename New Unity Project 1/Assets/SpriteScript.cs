using UnityEngine;
using System.Collections;

public class SpriteScript : MonoBehaviour {

    public string stringToEdit = "Hello World";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }

    
    void OnGUI()
    {
       //GUI.Label(new Rect(15, 15, 200, 20), stringToEdit);
    }
}

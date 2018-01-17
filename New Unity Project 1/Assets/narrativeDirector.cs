using UnityEngine;
using System.Collections;

public class narrativeDirector : MonoBehaviour {

    private CamControl CamController;
    private Transform speaker;
    private Transform secondSpeaker;
    private string lineToSpeak;

    // Use this for initialization
	void Start () {
         CamController = GetComponent<CamControl>();
        //CamController.pauseCam();
    }

    // Update is called once per frame
    void Update () {
	
	}


    public void executeDialog()
    {
        CamController.pauseCam();

    }

}

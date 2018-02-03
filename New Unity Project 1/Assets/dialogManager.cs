using UnityEngine;
using System.Collections;

public class dialogManager : Singleton<dialogManager>
{
    public string stringToEdit ;
    private string[] fullScript;
    private int currentLine;
    private bool inChat;
    // Use this for initialization
    void Start()
    {
        inChat = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void executeDialog()
    {
        currentLine = -1;
       // Camera.main.GetComponent<narrativeDirector>().executeDialog();
        Camera.main.GetComponent<CamControl>().pauseCam();
        //stringToEdit = fullScript[currentLine];

    }

    public void loadText(string[] _script)
    {
        fullScript = new string[_script.Length];
        for (int i = 0; i < _script.Length; i++)
            fullScript[i] = _script[i];
        stringToEdit = fullScript[currentLine];
        executeDialog();
        inChat = true;
        
    }

   void OnGUI()
    {
        if (stringToEdit != null)
        {
            GUI.Label(new Rect(15, 15, 200, 20), stringToEdit);
            if (Input.GetButton("Fire1") && inChat == true)
            {
                StartCoroutine("iterateLine");
                inChat = false;
            }
            
            if (currentLine  == fullScript.Length)
            {
                
                Camera.main.GetComponent<CamControl>().unpauseCam();
                inChat = false;
                for (int i = 0; i < fullScript.Length; i++)
                {
                    fullScript[i] = null;
                    
                }
            }

        }
    }

    IEnumerator iterateLine()
    {
        
        
       
        yield return new WaitForSeconds(.5f);
        currentLine++;
        
        if (fullScript[currentLine][0] == '<')
        {
            if (fullScript[currentLine][1] == 'i')
            { string noob;
                noob = fullScript[currentLine].Substring(fullScript[currentLine].IndexOf('>') + 1);
                Camera.main.GetComponent<CamControl>().focusOn(GameObject.Find(noob));
                currentLine++;
            }
               
        }
        
       stringToEdit = fullScript[currentLine];

        inChat = true;
    }

    private void moveCam(string _charID) 
    {
        
    }


}

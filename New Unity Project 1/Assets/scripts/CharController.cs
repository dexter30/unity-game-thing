using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

    private Vector3 newPosition;

    private Camera camRef;
    public float speedx;
    public float speedy;
    private float xMove, yMove;
    
    public float max, min;
    private GameObject fighter;


    private bool crouchBool = false;
    private bool blockBool = false;
    private bool dead = false;
    private bool InAir = false;
    public Animator animator;


    // Use this for initialization
    void Start () {
        speedx = 0f;
        speedy = 0f;
        xMove = 0.5f;
        yMove = 0.5f;
        max = 0.5f;
        min = -0.5f;
        fighter = GameObject.FindWithTag("Player");
        camRef = Camera.main;
        
    }

   
    // Update is called once per frame
    void Update() {


        if(Input.GetButton("Jump"))
        {
            
            animator.SetTrigger("JumpTrigger");
            StartCoroutine(COInAir(0.25f));
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                animator.SetBool("WalkRight", true);
                //transform.Rotate(0.0f, 5.0f, 0.0f);
            }
            else
            {
                animator.SetBool("WalkLeft", true);
                //transform.Rotate(0.0f, -5.0f, 0.0f);
            }
            speedx += (Input.GetAxis("Horizontal") * 0.1f);


        }
        else
        {
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            speedy += (Input.GetAxis("Vertical") * 0.1f);
            if (Input.GetAxis("Vertical") > 0.0f)
            { animator.SetBool("Walk Forward", true);
            }
            else animator.SetBool("Walk Backward", true);
        }
        else 
        {
            animator.SetBool("Walk Forward", false);
            animator.SetBool("Walk Backward", false);
        }
            if (speedx > max)
        {
            speedx = max;
        }
        else if (speedx < min)
        {
            speedx =  min;
        }

        if (speedy > max)
        {
            speedy = max;
        }
        else if (speedy < min)
        {
            speedy = min;
        }
        newPosition.x = speedx * xMove;
        newPosition.z = speedy * yMove;
        speedx -= speedx * 0.1f;
        speedy -= speedy * 0.1f;
        transform.Translate(newPosition);
        Quaternion tarDir = new Quaternion(0.0f, camRef.transform.rotation.y, 0.0f, camRef.transform.rotation.w);
        transform.rotation =  Quaternion.RotateTowards(transform.rotation, tarDir, 10.0f);
	}

    IEnumerator COInAir(float toAnimWindow)
    {
        yield return new WaitForSeconds(toAnimWindow);
        InAir = true;
        animator.SetBool("InAir", true);
        yield return new WaitForSeconds(0.5f);
        InAir = false;
        animator.SetBool("InAir", false);
    }
}

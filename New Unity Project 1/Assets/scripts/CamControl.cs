using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour {

    public float distance = 0.0f;
    public float height = 5.0f;

    public bool smoothRotation = true;
    public float rotationDamping = 10.0f;
    public float damping = 5.0f;

    public Vector2 clampInDegrees = new Vector2(360, 180);
    public bool lockCursor;
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);
    public Vector2 targetDirection;

    Vector2 _mouseAbsolute;
    Vector2 _smoothMouse;

    private Vector3 wantedPos;

    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;

    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    public float xSpeed = 5.0f;
    public float ySpeed = 5.0f;

    private bool scene = false;
    public GameObject target;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player");
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;

    }

    private void pcMovement()
    {
        if (target)
        {
            // if (Input.GetMouseButton(0))
            //  {
            velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.002f;
            velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.002f;
            //  }


        }
    }

    public void pauseCam()
    {
        scene = true;
    }
    public void unpauseCam()
    {
        scene = false;
        target = GameObject.FindWithTag("Player");
    }

    public void focusOn(GameObject _target)
    {
        target = _target;
       // Vector3 wantedPosition;
       //
       // wantedPosition = _target.TransformPoint(distance, height, 0);
       //
       // transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
       // transform.LookAt(_target, _target.up);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire2"))
        {
           

        }

        if(!scene)
            pcMovement();


       //     wantedPos = target.transform.TransformPoint(distance, height, -5.0f);
       //transform.position = Vector3.Lerp(transform.position, wantedPos, Time.deltaTime * 5.0f);
       //transform.LookAt(target.transform, target.transform.up);
        rotationYAxis += velocityX;
        rotationXAxis -= velocityY;
        rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
        Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
        Quaternion rotation = toRotation;


        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
        RaycastHit hit;
        if (Physics.Linecast(target.transform.position, transform.position, out hit))
        {
            distance -= hit.distance;
        }
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.transform.position;


        transform.rotation = rotation;
        transform.position = position;
        velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
        velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);


       // print(transform.forward);
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOverheadController : MonoBehaviour
{
    [SerializeField]
    private float zoomSpeed = 500;
    [SerializeField]
    private float sideToSideSpeed = 10f;
    [SerializeField]
    private float smoothTime = 0.25f;
    [SerializeField]
    private float sideBoarder = 30f;
    [SerializeField]
    private float topBottomBoarder = 30f;

    [Tooltip("X = Change in elevation.\nY = Angle upwards")]
    public AnimationCurve cameraHorisonCurve = new AnimationCurve(new Keyframe(3f, 30f, -1f, -5f), new Keyframe(7f, 0f, -0.1f, 0f), new Keyframe(20f, 0f, 0f, 0f));

    private Vector3 origin;
    private Vector3 difference;
    Vector3 velocity = Vector3.zero;
    //private bool drag = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 height = transform.position;
        height.y = height.y - (Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);

        Vector3 mousePos = Input.mousePosition;
        Vector3 screenChange = Vector3.zero;
        
        if (mousePos.x <= sideBoarder)
        {
            screenChange.z = +sideToSideSpeed;
        }
        else if (mousePos.x >= Screen.width - sideBoarder)
        {
            screenChange.z = -sideToSideSpeed;
        }
        if (mousePos.y <= topBottomBoarder)
        {
            screenChange.x = -sideToSideSpeed;
        }
        else if (mousePos.y >= Screen.height - topBottomBoarder)
        {
            screenChange.x = +sideToSideSpeed;
        }

        Vector3 finalMove = new Vector3(transform.position.x + screenChange.x, height.y, transform.position.z + screenChange.z);

        transform.position = Vector3.SmoothDamp(transform.position,finalMove,ref velocity, smoothTime);
        transform.rotation = Quaternion.Euler(90f - cameraHorisonCurve.Evaluate(transform.position.y), 90f, 0f);

        //if (Input.GetMouseButton(2))
        //{
        //    difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
        //    if (drag == false)
        //    {
        //        drag = true;
        //        origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    }
        //
        //}
        //else
        //{
        //    drag = false;
        //}
        //
        //if (drag)
        //{
        //    Debug.Log("Dragging");
        //    Vector3 pos = transform.position;
        //    pos.x = pos.x - (difference.x - origin.x);
        //    pos.z = pos.z - (difference.z - origin.z);
        //    transform.position = pos;
        //    
        //}

    }
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, 3f, 20f);// work on world boarders
        //pos.z = Mathf.Clamp(pos.z, 3f, 20f);
        pos.y = Mathf.Clamp(pos.y, 3f, 20f);
        transform.position = pos;
    }
}

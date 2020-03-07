using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // target player1 object

    public Vector3 offset; //vector used to offset camera

    public bool useOffsetValues; //optional, if player wants custom offset values

    public float rotateSpeed; //rotation speed of camera

    public Transform pivot; //pivot camera to move with player movement

    public float maxViewAngle; //max and min view for player rotation
    public float minViewAngle;

    public bool invertY; //if player wants to invert their camera

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValues)
        { //if offset values are turned off this function executes at run time
            offset = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = null;
        Cursor.lockState = CursorLockMode.Locked; //remove cursor from screen
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.transform.position = target.transform.position; // pivot moves with player
        //get the x position of the mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed; //rotating camera on x axis
        pivot.Rotate(0, horizontal, 0); //apllying rotation to pivot rather than target

        //get y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed; //rotating camera on y axis

        //code block to give players the option of inverting thier camera
        if (invertY)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //setting limit for how far up and down the camera can rotate
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        { //eulerAngles.x instead of .x to avoid taking the x value of the Quaternion
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        { //315 is 45 degrees below x axis
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        // move camera based on the current rotation of the target and the orginal offset
        float desired_Yangle = pivot.eulerAngles.y; //changing target to pivot rotatiion for greater camera control
        float desired_Xangle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desired_Xangle, desired_Yangle, 0);
        transform.position = target.position - (rotation * offset);

        transform.LookAt(target);

        if (transform.position.y < target.position.y)
        { //prevent camera from going through the ground if less than player1 "target position"
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
        }
    }
}

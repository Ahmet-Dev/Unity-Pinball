using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour {

    /*public float radius = 0.5f;*/

    private Vector3 lastPosition;

    public Transform sphere3D;
    public float ballRadius = 1;
    float c;
    Rigidbody2D rb;
    Vector3 axis;
    float angle;


    // Use this for initialization
    void Start() {
        lastPosition = transform.position;

        /*c = 2 * Mathf.PI * ballRadius;
        rb = GetComponent<Rigidbody2D>();*/
    }

    // Update is called once per frame
    void Update() {
        /*axis = Vector3.Cross(rb.velocity, Vector3.forward);
        angle = (rb.velocity.magnitude * 360 / c);
        sphere3D.Rotate(axis, angle * 2 * Time.deltaTime, Space.World);*/
    }

    void FixedUpdate() {
        rotateBall();
        lastPosition = transform.position;
    }

    /// <summary>
    /// Rotate the 3D mesh with quaternions!
    /// </summary>
    private void rotateBall() {
        if (ballRadius == 0) {
            // can't rotate ball
            return;
        }
        Vector3 currentToLast = lastPosition - transform.position;

        // segment length that the ball rolled along its surface
        float segment = currentToLast.magnitude;

        if (segment == 0) {
            return;
        }

        // to build a Quaternion to hold the desired rotation
        Vector3 ballDown = new Vector3(0, 0, 1);

        // use Cross Product to find the axis of rotation 
        Vector3 axis = Vector3.Cross(ballDown, currentToLast);

        // Cross Product will fail if both vectors are parallel or perpendicular
        if (axis == Vector3.zero) {
            // this should never happen because currentToLast.z is always 0
            return;
        }

        // next, the angle theta:

        // arc length formula
        // s = r * theta
        // theta = s / r
        // http://www.mathopenref.com/arclength.html
        float theta = segment / ballRadius; // in radians
        float thetaDegrees = theta * 180 / Mathf.PI;

        // create the rotation Quaternion
        Quaternion q = Quaternion.AngleAxis(thetaDegrees * 3.9f, axis);

        // apply rotation to the transform
        sphere3D.transform.rotation = q * sphere3D.transform.rotation;
    }

}

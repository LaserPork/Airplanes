using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float torque = 0.5f;
    public float force = 10;
    public Rigidbody2D airplaneBody;
    // Start is called before the first frame update
    void Start()
    {
        airplaneBody = GetComponent<Rigidbody2D>();
        Collider2D airplaneCollider = GetComponent<Collider2D>();
        airplaneBody.centerOfMass += new Vector2(airplaneCollider.bounds.size.x / 10,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            airplaneBody.AddTorque(-torque);
        }else if(Input.GetAxis("Horizontal") < 0)
        {
            airplaneBody.AddTorque(torque);
        }

        if(Input.GetKey("space"))
        {
            airplaneBody.AddRelativeForce(new Vector2(force,0));
        }
    }
}

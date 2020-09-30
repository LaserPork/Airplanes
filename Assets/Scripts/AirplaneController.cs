using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float force = 0;
    public Rigidbody2D airplaneBody;
    // Start is called before the first frame update
    void Start()
    {
        airplaneBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        airplaneBody.AddForce(new Vector2(force,0));
    }
}

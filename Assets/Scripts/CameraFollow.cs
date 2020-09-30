using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject[] following;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followingCenter = new Vector3(0,0,0);
        for(int i = 0; i < following.Length; i++)
        {
            followingCenter += following[i].transform.position;
        }
        followingCenter /= following.Length;
        followingCenter.z = -10;

        gameObject.transform.position = followingCenter;
    }
}

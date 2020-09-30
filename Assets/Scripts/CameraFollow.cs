using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Camera currentCamera;
    public GameObject[] following;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followingCenter = new Vector3(0,0,0);
        Vector2 minValue = new Vector2(float.MaxValue, float.MaxValue);
        Vector2 maxValue = new Vector2(float.MinValue, float.MinValue);
        for(int i = 0; i < following.Length; i++)
        {
            followingCenter += following[i].transform.position;
            if(following[i].transform.position.x < minValue.x)
            {
                minValue.x = following[i].transform.position.x;
            }
            if(following[i].transform.position.y < minValue.y)
            {
                minValue.y = following[i].transform.position.y;
            }
            if(following[i].transform.position.x > maxValue.x)
            {
                maxValue.x = following[i].transform.position.x;
            }
            if(following[i].transform.position.y > maxValue.y)
            {
                maxValue.y = following[i].transform.position.y;
            }
        }
        followingCenter /= following.Length;
        followingCenter.z = -10;

        gameObject.transform.position = followingCenter;


        float vertExtent = currentCamera.orthographicSize;    
        float horzExtent = vertExtent * Screen.width / Screen.height;
        
        float requiredWidth = maxValue.x - minValue.x;
        float requiredHeight = maxValue.y - minValue.y;

    
        if(requiredWidth - horzExtent < requiredHeight - vertExtent)
        {
            currentCamera.orthographicSize = requiredHeight * 1.2f;
        }
        else
        {
            currentCamera.orthographicSize = requiredWidth * 1.2f * Screen.height / Screen.width;
        }
        
    }
}

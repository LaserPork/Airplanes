using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeater : MonoBehaviour
{
    public GameObject ground;
    
    private GameObject leftMost;
    private GameObject rightMost;
    private Camera currentCamera;
    // Start is called before the first frame update
    void Start()
    {
        currentCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float vertExtent = currentCamera.orthographicSize;    
        float horzExtent = vertExtent * Screen.width / Screen.height;
        
        Transform leftMost = getLeftMost();
        Transform rightMost = getRightMost();

        if(currentCamera.transform.position.x + 2*horzExtent > rightMost.position.x - rightMost.localScale.x) 
        {
            Vector3 oldPosition = rightMost.position;
            oldPosition.x += rightMost.transform.localScale.x;
            GameObject clone = Instantiate(rightMost.gameObject);
            clone.transform.SetParent(gameObject.transform);
            clone.transform.position = oldPosition;
            rightMost = getRightMost();
            Debug.Log(rightMost.position.x);
        }
       
    }

    Transform getLeftMost()
    {
        Transform leftMost = transform.GetChild(0);
        foreach (Transform child in transform) 
        {
            if(child.transform.position.x < leftMost.position.x) 
            {
                leftMost = child;
            }
        }

        return leftMost;
    }

    Transform getRightMost()
    {
        Transform rightMost = transform.GetChild(0);
        foreach (Transform child in transform) 
        {
            if(child.transform.position.x > rightMost.position.x) 
            {
                rightMost = child;
            }
        }

        return rightMost;
    }

}

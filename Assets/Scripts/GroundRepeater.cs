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
       
        addGround();
        removeGround();
    }

    void removeGround() 
    {
        float vertExtent = currentCamera.orthographicSize;    
        float horzExtent = vertExtent * Screen.width / Screen.height;

        Transform rightMost = getRightMost();
        if(currentCamera.transform.position.x + 2*horzExtent < rightMost.position.x - rightMost.localScale.x) 
        {
            Destroy(rightMost.gameObject);
            rightMost = getRightMost();
        }

        Transform leftMost = getLeftMost();
        if(currentCamera.transform.position.x - 2*horzExtent > leftMost.position.x + leftMost.localScale.x) 
        {
            Destroy(leftMost.gameObject);
            leftMost = getLeftMost();
        }
    }
    void addGround()
    {
        float vertExtent = currentCamera.orthographicSize;    
        float horzExtent = vertExtent * Screen.width / Screen.height;

        Transform rightMost = getRightMost();
        while(currentCamera.transform.position.x + horzExtent > rightMost.position.x - rightMost.localScale.x) 
        {
            Vector3 oldPosition = rightMost.position;
            oldPosition.x += rightMost.transform.localScale.x;
            GameObject clone = Instantiate(rightMost.gameObject);
            clone.name = rightMost.name;
            clone.transform.SetParent(gameObject.transform);
            clone.transform.position = oldPosition;
            rightMost = getRightMost();
        }

        Transform leftMost = getLeftMost();
        while(currentCamera.transform.position.x - horzExtent < leftMost.position.x + leftMost.localScale.x) 
        {
            Vector3 oldPosition = leftMost.position;
            oldPosition.x -= leftMost.transform.localScale.x;
            GameObject clone = Instantiate(leftMost.gameObject);
            clone.name = leftMost.name;
            clone.transform.SetParent(gameObject.transform);
            clone.transform.position = oldPosition;
            leftMost = getLeftMost();
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

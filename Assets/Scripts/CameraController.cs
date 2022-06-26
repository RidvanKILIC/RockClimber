using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject target;
    private Vector3 targetPosition;

    public float smoothing;
    public bool moveUpTrigger = false;
 
    void Update()
    {
        targetPosition.y = target.transform.position.y;
        targetPosition.x = transform.position.x;
        targetPosition.z = transform.position.z;
        //transform.position += new Vector3(0, 0.3f * Time.deltaTime, 0);

    }

    private void LateUpdate()
    {
        if (moveUpTrigger)
            moveup();
    }
    public bool isHigher()
    {
        if (target.transform.position.y > transform.position.y)
        {
            return true;
        }
        else
        {
            return false;
        }  
    }
    public void moveup()
    {
        if (isHigher() && moveUpTrigger)
        {
            transform.position = Vector3.Lerp(transform.position,targetPosition, smoothing * Time.deltaTime);
            Debug.Log("Moved Up");
            float t = smoothing * Time.deltaTime;
            if (t > smoothing)
                moveUpTrigger = false;
            //StartCoroutine(delayCoroutine());
        }
       
    }
   /*IEnumerator delayCoroutine()
    {
       yield  return new  WaitForSeconds(5f);
       moveUpTrigger = false;
    }*/
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class checkHandCollsion : MonoBehaviour
{
    HingeJoint joint;
    bool collisionCoolDown = false;
    playerHold _playerHold;
    bool held=false;
    private void Start()
    {
        _playerHold = GameObject.Find("player").GetComponent<playerHold>();
        joint = GetComponent<HingeJoint>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && (!collisionCoolDown && !held) && !_playerHold.getHoldingState())
        {
            
            //Debug.Log("Hand Collided");
            joint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            _playerHold.setHoldingRock(this.gameObject);
            held = true;
        }
    }
    //private void OnTrEnter(Collision collision)
    //{

    //}
    public void relase()
    {
        joint.connectedBody = null;
        collisionCoolDown = true;
        held = false;
        _playerHold.setHoldingRock();
        StartCoroutine(delayCouroutine());
    }
    IEnumerator delayCouroutine()
    {
        yield return new WaitForSeconds(1f);
        collisionCoolDown = false;
    }
}

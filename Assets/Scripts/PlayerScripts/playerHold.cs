using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameVariables;
public class playerHold : MonoBehaviour
{
    //HingeJoint joint;
    Vector3 targetPos;
    RaycastHit hit;
    private bool hooked = false;
    private float distance = 3f;
    [SerializeField]
    private Rigidbody rb;
    float force;
    bool forceCooldown = false;
    float forceCoolDownTime;
    [SerializeField]
    private Rigidbody leftHandRB;
    [SerializeField]
    private Rigidbody rightHandRB;
    [SerializeField]
    private LayerMask mask;
    private CameraController camController;
    GameObject currentNode;
    bool moveLeftHand,moveRightHand = false;
    Vector3 moveDir;
    RaycastHit currentHit;
    gameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        force = GameVariables.playerForcePower;
        forceCoolDownTime = GameVariables.playerAddForceCoolDown;
        //joint = GetComponentInChildren<HingeJoint>();
        //rb = GetComponentInChildren<Rigidbody>();
        _gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
        camController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        currentNode = GameObject.Find("StartingRock");
    }
    // Update is called once per frame
    void Update()
    {
        //if (!rb.gameObject.GetComponent<Renderer>().isVisible)
        //{
        //    _gameManager.gameOver();
        //}
        //else 
        if (Input.GetMouseButtonDown(0) && !_gameManager.isGameOver)
        {
            checkState();
        }

    }
    void checkState()
    {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("hitted");
                if (hit.collider.gameObject.CompareTag("Grab"))
                {
                    Vector3 dir = (hit.point - rb.transform.position).normalized;
                    currentHit = hit;
                    moveDir = dir;
                    if (hit.point.x < rb.transform.position.x)
                    {
                        //Debug.Log("Move Left");
                        moveRightHand = false;
                        moveLeftHand = true;
                    }
                    else
                    {
                        //Debug.Log("Move Right");
                        moveLeftHand = false;
                        moveRightHand = true;
                    }
                }
            if (moveLeftHand && !forceCooldown /*&& getHoldingState()*/)
            {
                forceCooldown = true;
                addForceToMainBody("left");
            }
            else if (moveRightHand && !forceCooldown /*&& getHoldingState()*/)
            {
                forceCooldown = true;
                addForceToMainBody("right");
            }
        }
    }
    public void clearAddingForceVariables()
    {
        
        if (currentNode != null)
        {
            Debug.Log("curret node name " + currentNode.name);
            currentNode.GetComponent<checkHandCollsion>().relase();
        }
        moveLeftHand = false;
        moveRightHand = false;
        rb.velocity = Vector3.zero;
        //leftHandRB.velocity = Vector3.zero;
        //rightHandRB.velocity = Vector3.zero;
    }
    void addForceToMainBody(string side)
    {
        

        if (side.Equals("left"))
        {
            leftHandRB.AddForce(moveDir * force / 6, ForceMode.Impulse);
            rb.AddForce(moveDir * (4 * force) , ForceMode.Impulse);
        }

        else if (side.Equals("right"))
        {
            rightHandRB.AddForce(moveDir * force / 6, ForceMode.Impulse);
            rb.AddForce(moveDir * force, ForceMode.Impulse);
        }
        StartCoroutine(delayCoroutine());
        //Debug.Log("ForeceAdded");
        
    }
    public void setHoldingRock(GameObject rock=null)
    {
        currentNode = rock;
        if (currentNode!=null && ( currentNode.transform.position.y > camController.transform.position.y))
        {
            if (currentNode.gameObject.name.Equals("Finish"))
            {
                _gameManager.gameOver();
            }
            camController.moveUpTrigger = true;
        }
       
    }
    public bool getHoldingState()
    {
        if (currentNode != null)
            return true;
        else
            return false;
    }
    IEnumerator delayCoroutine()
    {
        clearAddingForceVariables();
        yield return new WaitForSeconds(forceCoolDownTime);
        forceCooldown = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostacle_Saw : MonoBehaviour,IObstacle
{
    public Saw _saw;
    Rigidbody rb;
    bool coolDownNeeded=false;
    [SerializeField]
    LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _saw.rb = this.rb;
    }

    // Update is called once per frame
    void Update()
    {
        _saw.movement();
        checkEdges();
    }
    void attack(GameObject target)
    {
       
    }
    public void checkEdges()
    {
        RaycastHit hit;
        Debug.DrawRay(new Vector3(rb.transform.position.x - 5F, rb.transform.position.y, rb.transform.position.z), rb.transform.right * 10f, Color.green);
        if (Physics.Raycast(new Vector3(rb.transform.position.x - 5F, rb.transform.position.y, rb.transform.position.z), rb.transform.right, out hit, 10f, mask))
        {
            if ((hit.collider != null) && (hit.collider.gameObject.tag.Equals("Edge")) && !coolDownNeeded)
            {
                if (hit.collider.gameObject.tag.Equals("Player"))
                {
                    this.GetComponent<IObstacle>().attack(hit.collider.gameObject);
                }
                _saw.changeDir = !_saw.changeDir;
                //Debug.Log("Hitted waall" + hit.collider.gameObject.name);
                coolDownNeeded = true;
                StartCoroutine(coolDown());
            }
        }

    }
    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(1f);
        coolDownNeeded = false;
    }

    void IObstacle.attack(GameObject target)
    {
        _saw.attack(target);
    }
}

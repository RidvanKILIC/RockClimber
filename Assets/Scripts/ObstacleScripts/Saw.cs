using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SawObject", menuName = "Ostacle/Saw")]
public class Saw : ScriptableObject
{
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    [SerializeField]
    float speed;
    [SerializeField]
    int Damage;
    public Rigidbody rb;
    Collider col;

    public bool changeDir;
    public void attack(GameObject target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            var hit = GameObject.Find("Player").GetComponent<IDamagable>();
            if (hit != null)
                hit.Damage(Damage);
            Debug.Log("Player Hitted");
        }

    }

   public void movement()
    {
        if (changeDir)
        {
            rb.velocity = (Vector3.right) * -speed * Time.deltaTime;
        }
        else if (!changeDir)
        {
            rb.velocity = (Vector3.right) * speed * Time.deltaTime;
        }
    }

}

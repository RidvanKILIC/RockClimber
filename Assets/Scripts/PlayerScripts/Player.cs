using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IDamagable
{
    [SerializeField]
    int health;
    gameManager _gameManager;
    public int Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    
   /// <summary>
   /// Just if we want to use health decrese system for now only we are calling gameOver method
   /// </summary>
   /// <param name="DamageTaken"></param>
    public void Damage(int DamageTaken)
    {
        _gameManager.gameOver();
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = this.health;
        _gameManager = GameObject.Find("GamaManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

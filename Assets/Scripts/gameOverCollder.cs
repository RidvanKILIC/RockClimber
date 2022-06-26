using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverCollder : MonoBehaviour
{
    gameManager _gameManager;
    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.gameOver();
        }
    }
}

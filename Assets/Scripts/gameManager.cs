using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    playerHold _playerHold;
    public bool isGameOver=false;
    // Start is called before the first frame update
    void Start()
    {
        _playerHold = GameObject.Find("player").GetComponent<playerHold>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameOver()
    {
        isGameOver = true;
        _playerHold.clearAddingForceVariables();
        UIManager.sharedInstance.gameOver();
    }
    public void startGame()
    {
        UIManager.sharedInstance.startGame();
        //_playerHold.clearAddingForceVariables();
    }
}

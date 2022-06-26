using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    GameObject startPanel;
    public static UIManager sharedInstance;
    // Start is called before the first frame update
    private void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        startPanel.SetActive(false);
    }
    public void gameOver()
    {
        gameOverPanel.SetActive(true);
    }
}

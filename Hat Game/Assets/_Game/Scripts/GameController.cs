using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    [SerializeField] private float startTime;
    public float currentTime;
    public bool gameStarted;
    private UIController uIController; //essa variável controlola os paines da classe UIController
    void Start()
    {
        gameStarted = false;
        uIController = FindObjectOfType<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountdownTime();
    }

    public void BackMainMenu()
    {
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountdownTime");
    }

    public void InvokeCountdownTime()
    {
        InvokeRepeating("CountdownTime", 1f, 1f);
    }

    public void CountdownTime() //Serve para ter uma contagem regressiva para terminar o jogo
    {
        if (currentTime > 0f && gameStarted) //enquanto o jogo estiver acontecendo
        {
            currentTime -= 1f;
            
        }else //quando chegar no game over
        {
            uIController.panelGameOver.gameObject.SetActive(true);
            uIController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            currentTime = 0f;
            CancelInvoke("CountdownTime");
            return;
        }
        
    }
}

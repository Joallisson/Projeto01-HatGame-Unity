using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public int score;
    private int highScore;
    [SerializeField] private float startTime;
    private float currentTime;
    [HideInInspector] public bool gameStarted;
    private UIController uIController; //essa variável controlola os paines da classe UIController
    private SpawnController spawnController;
    [SerializeField] private Transform player; //vai armazenar o player
    private Vector2 playerPosition; //vai armazenar a posição do player
    
    private void Awake() {
        DeleteHighScore();
    }

    void Start()
    {
        gameStarted = false;
        uIController = FindObjectOfType<UIController>();
        spawnController = FindObjectOfType<SpawnController>();
        highScore = GetScore();
        uIController.txtTime.text = currentTime.ToString();
        playerPosition = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyAllBalls() //destroi todas as bolas criadas
    {
        foreach (Transform child in spawnController.allBallsParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void SaveScore() //salvando a maior pontuação
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore); //seta o valor da variavel highScore e armazena dentro da chave highScore
        }else
        {
            return;
        }
    }

    public int GetScore()   
    {
        int highScore = PlayerPrefs.GetInt("highScore"); //recupera o valor da chava highScore
        return highScore;
    }

    public void DeleteHighScore() //apagando a maior pontuação
    {
        PlayerPrefs.DeleteKey("highScore");
    }

    public void StartGame() //Esse método é chamdo dentro do UIController quando botão de começar o jogo é clicado
    {
        score = 0;
        currentTime = startTime;
        gameStarted = true;
        InvokeCountdownTime(); //chamando o método InvokeCountdownTime()
        player.position = playerPosition;
    }

    public void BackMainMenu()
    {
        score = 0;
        currentTime = 0f;
        gameStarted = false;
        CancelInvoke("CountdownTime"); //Esse método só serve para cancelar o CountdownTime
        player.position = playerPosition;
    }

    public void InvokeCountdownTime() //Esse método só serve para chamar o CountdownTime 
    {
        InvokeRepeating("CountdownTime", 0f, 1f);
    }

    public void CountdownTime() //Serve para ter uma contagem regressiva para terminar o jogo
    {
        uIController.txtTime.text = currentTime.ToString();


        if (currentTime > 0f && gameStarted) //enquanto o jogo estiver acontecendo
        {
            currentTime -= 1f;
            
        }else //quando chegar no game over
        {
            uIController.panelGameOver.gameObject.SetActive(true);
            uIController.panelGame.gameObject.SetActive(false);
            gameStarted = false;
            SaveScore();
            currentTime = 0f;
            CancelInvoke("CountdownTime");
            return;
        }
        
    }
}

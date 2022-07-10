using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameController gameController; //Criando variavel a partir da classe GameController
    public GameObject panelMainMenu, panelGame, panelPause, panelGameOver; //Crinado as variáveis dos painéis

    public TMP_Text txtHighScore; //texyo da maior pontuação no painel do usuário

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        txtHighScore.text = "High Score: " + gameController.GetScore().ToString(); //alterando o High Score do painel do usuário para o valor da variável
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonExit(){//Qunado clicar no botão de sair

        /*//Forma generica
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        } 
        */

        //Forma Android
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void ButtonStartGame()
    {     
        panelMainMenu.gameObject.SetActive(false); //Quando apertar no botão start o painel de menu principal é desativado
        panelGame.gameObject.SetActive(true); //Quando apertar no botão start mostra o painel do jogo
        gameController.StartGame(); //Quando apertar no botão start inicia o jogo
    }

    public void ButtonPause() //Quando apertar o botão de Pause, mostra o painel do de pause e desativa o de jogo
    {
        panelGame.gameObject.SetActive(false); //Quando apertar no botão pause o painel de do jogo é desativado
        panelPause.gameObject.SetActive(true);
    }

    public void ButtonResume() //Quando apertar o botão de Resume, mostra o painel do jogo e desativa o de pause
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
    }

    public void ButtonRestart()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        gameController.StartGame();
    }

    public void ButtonBackMainMenu()
    {
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        panelGameOver.gameObject.SetActive(false);
        gameController.BackMainMenu();
        txtHighScore.text = "High Score: " + gameController.GetScore().ToString();
    }













    
}

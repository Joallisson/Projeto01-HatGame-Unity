using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float topDistance, lateralMargin;
    private Vector2 screenWidth;
    private GameController gameController;
    public Transform allBallsParent; //sempre que uma bola de boliche for criada ela deve ser filho desse objeto

    void Awake() {
        Initiallize();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnInvoke", 2.0f, Random.Range(2.0f, 3.0f)); //esse método serve para chamar os métodos que estãod entro dele repetidas vezes
    }

    private void Initiallize()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height)); //passamos a largura do safeArea
        Vector2 heightPosition = new Vector2(transform.position.x, Camera.main.orthographicSize + topDistance); //passamos a altura de onde a bola de boliche vai começar a surgir
        transform.position = heightPosition; //a posição do spawn vai receber a altura criada anteriormente
        gameController = FindObjectOfType<GameController>();
    }

    private void SpawnInvoke() //esse método é para chamar o método Spawn que é do tipo IEnumerator
    {
        StartCoroutine(Spawn()); //é assim que se chama um método do tipo IEnumerator
    }

    private IEnumerator Spawn() //Acontecer em determinado intervalo de tempo
    {
        if (gameController.gameStarted) //SE o jogo começar, fica criando as bolas
        {
             yield return new WaitForSeconds(0f); //o que estiver abaixo desta linha vai acontecer depois de 2 segundo, e o que estiver antes dessa linha vai acontecer instantâneamente
            transform.position = new Vector2(Random.Range(-screenWidth.x + lateralMargin, screenWidth.x - lateralMargin), transform.position.y); //O transform.position vai receber uma posição aleatória no eixo x //definindo a posição em que o spawn vai sugir
            GameObject tempBallPrefab = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject; //instamciando bola de boliche nas coordenadas criadas
            tempBallPrefab.transform.parent = allBallsParent; //estamo0s dizendo que os objetos instanciados são filhos do allBallsParent
        
        }else
        {
            yield return null;
        }
       

    }
}

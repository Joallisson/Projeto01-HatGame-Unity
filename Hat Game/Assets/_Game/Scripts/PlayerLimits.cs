using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour
{
    private float minX, maxX;

    [SerializeField] private float minDistancie, maxDistancie; 

    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerPosition();
    }

    private void SetMinAndMaxX() //delimitar espaço da camera para o chapeu percorrer
    {
        //atribuindo limites do safeArea para o mundo da unity. para delimitar o limite o espaço que o chapéu pode percorrer na teal horizontalmente
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0f, 0f));
        maxX = bounds.x - maxDistancie;
        minX = -bounds.x + minDistancie;
    }

    private void SetPlayerPosition()
    {
        if(transform.position.x < minX) //Se o chapeu chegar no limite da esquerda, então o chapéu para e não se move mais para a esquerda
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }else if(transform.position.x > maxX)  //Se o chapeu chegar no limite da direita, então o chapéu para e não se move mais para a direita
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }
}

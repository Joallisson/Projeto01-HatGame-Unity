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
    void Start()
    {
        score = 0;
        currentTime = startTime;
        gameStarted = false;

    }

    // Update is called once per frame
    void Update()
    {
        CountdownTime();
    }

    public void CountdownTime()
    {
        if (currentTime > 0f && gameStarted)
        {
            currentTime -= Time.deltaTime;
            float currentTimeToInt = Mathf.RoundToInt(currentTime);
            Debug.Log(currentTimeToInt);
            
        }else
        {
            return;
        }
        
    }
}

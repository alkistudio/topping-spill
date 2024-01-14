using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public Customer c;
    
    public CUIDisplay cUIDisplay;
    public ScoringSystem scoringSystem;
    public ToppingSpawner toppingSpawner;

    private float timeHeld;
    private bool inProgress = false;

    public float minSpawnInterval = 20f;
    public float maxSpawnInterval = 40f;


    void Start()
    {
        Debug.Log("OrderManager Start() Running");
    }

    // Update is called once per frame
    void Update()
    {
        if (inProgress)
        {
            timeHeld += Time.deltaTime;
            if(timeHeld > c.patience)
            { 
                Debug.Log("Time's up!");
                EndOrder();
            }
        }
    }

    public void StartOrder(Customer currentCustomer)
    {
        timeHeld = 0;
        inProgress = true;
        toppingSpawner.StartSpawn();
        c = currentCustomer;
        cUIDisplay.DisplayOrder(c);
        Debug.Log("StartOrder() running! You have this much time:"+c.patience);
    }

    public void EndOrder()
    {
        inProgress = false;
        Debug.Log("Order is done!");
        toppingSpawner.StopSpawn();
        float score = scoringSystem.CalcScore(c, timeHeld);
        Debug.Log($"Score for Customer is: {score}");
        float tip = score * c.tip;
        cUIDisplay.DisplayScore(score, tip);
    }


}

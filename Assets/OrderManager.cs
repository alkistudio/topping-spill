using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public Customer c;
    
    public CUIDisplay cUIDisplay;
    public ScoringSystem scoringSystem;

    private float timeHeld;
    private bool inProgress;

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
            // !! Add timer UI update
        }
    }

    public void StartOrder(Customer currentCustomer)
    {
        timeHeld = 0;
        c = currentCustomer;
        cUIDisplay.DisplayOrder(c);
        
        scoringSystem.check();
        
        
        
        //float score = scoringSystem.CalcScore(c, timeHeld);
        //Debug.Log($"Score for Customer is: {score}");
    }


}

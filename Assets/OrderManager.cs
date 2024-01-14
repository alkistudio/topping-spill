using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public QueueManager queueManager;
    public CUIDisplay cUIDisplay;
    public ScoringSystem scoringSystem;

    private float timeHeld;
    private bool isToppingTime;

    public float minSpawnInterval = 20f;
    public float maxSpawnInterval = 40f;


    void Start()
    {
        Debug.Log("OrderManager Start() Running");
        //StartCoroutine(SpawnCustomersRandomly());
        //queueManager.PushCustomer(CreateRandomCustomer());
    }

    // Update is called once per frame
    void Update()
    {
        if (isToppingTime)
        {
            timeHeld += Time.deltaTime;
            // !! Add timer UI update
        }
    }
    public void ToppingTime(bool toppingTime)
    {
        isToppingTime = toppingTime;

        if (!toppingTime)
        {
            // release cone + customer, run scoring
            Customer currentCustomer = queueManager.PopCustomer();

            if(currentCustomer != null)
            {
                float score = scoringSystem.CalcScore(currentCustomer, timeHeld, currentCustomer.patience);
                Debug.Log($"Score for Customer is: {score}");
            }

            timeHeld = 0f;
            DisplayNextCustomer();
        }
    }

    public void DisplayNextCustomer()
    {
        Customer nextCustomer = queueManager.PopCustomer();
        if (nextCustomer != null)
        {
            cUIDisplay.DisplayOrder(nextCustomer);
        }
        Debug.Log("DisplayNextCustomer() -> No more customers!");
    }
}

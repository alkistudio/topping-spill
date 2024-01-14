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
        queueManager.PushCustomer(CreateRandomCustomer());
    }

    Customer CreateRandomCustomer()
    {
        Debug.Log("CreateRandomCustomer() Running");
        Customer randomCustomer = gameObject.AddComponent<Customer>();
        randomCustomer.customerID = 0;
        randomCustomer.talkingSpeed = 10;
        randomCustomer.patience = 30;
        randomCustomer.tip = 25;
        Order exOrder = new();
        exOrder.toppingAmount = new int[] { 0, 1, 2, 1 };
        randomCustomer.order = exOrder;

        cUIDisplay.DisplayOrder(randomCustomer);

        return randomCustomer;
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
        }
    }

    public void DisplayNextCustomer()
    {
        Customer nextCustomer = queueManager.PopCustomer();
        if (nextCustomer != null)
        {
            cUIDisplay.DisplayOrder(nextCustomer);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour {

    private Queue<Customer> cQueue = new Queue<Customer>();
    private OrderManager orderManager;
    public CUIDisplay cUIDisplay;
    public ScoringSystem scoringSystem;



    void Start()
    {
        Debug.Log("QueueManager Start() Running");
        orderManager = gameObject.AddComponent<OrderManager>();
        //StartCoroutine(SpawnCustomersRandomly());
        PushCustomer(CreateRandomCustomer());
        DoNextCustomer();
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

        //cUIDisplay.DisplayOrder(randomCustomer);

        return randomCustomer;
    }

    // Queue functions ===========================================================



    public void DoNextCustomer()
    {
        Customer nextCustomer = PopCustomer();
        if (nextCustomer != null)
        {
            //cUIDisplay.DisplayOrder(nextCustomer);
            orderManager.cUIDisplay = cUIDisplay;
            orderManager.scoringSystem = scoringSystem;
            orderManager.StartOrder(nextCustomer);
        }
        Debug.Log("DioNextCustomer() -> No more customers!");
    }

    // Base Queue functions ------------------------------------------------------

    public void PushCustomer(Customer customer)
    {
        cQueue.Enqueue(customer);
    }

    public Customer PopCustomer()
    {
        if(cQueue.Count > 0)
        {
            return cQueue.Dequeue();
        }
        return null;
    }
}

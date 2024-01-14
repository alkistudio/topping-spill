using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour {

    private Queue<Customer> cQueue = new Queue<Customer>();

    public CUIDisplay cUIDisplay;



    void Start()
    {
        Debug.Log("QueueManager Start() Running");
        //StartCoroutine(SpawnCustomersRandomly());
        PushCustomer(CreateRandomCustomer());
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

    // Queue functions ------------------------------------------------------

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

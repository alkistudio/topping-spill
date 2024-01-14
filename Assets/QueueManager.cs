using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour {

    private Queue<Customer> cQueue = new Queue<Customer>();

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

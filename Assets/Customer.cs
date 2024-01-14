using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int[] toppingAmount; // Amount of topping (0: None, 1: A few, 2: Normal, 3: A lot)
}


public class Customer : MonoBehaviour
{
    public int customerID;
    public float talkingSpeed;
    public float patience;
    public float tip;
    public Order order;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIDisplay : MonoBehaviour
{
    public Text orderText;
    public Image orderBox;

    public void DisplayOrder(Customer customer)
    {
        string orderString = "Can I get ";
        for (int i = 0; i< customer.order.toppingAmount.Length; i++)
        {
            switch (customer.order.toppingAmount[i])
            {
                case 0:
                    break;
                case 1:
                    orderString += "only a few "+ToString(i) +", ";
                    break;
                case 2:
                    orderString += ToString(i) + ", ";
                    break;
                case 3:
                    orderString += "a lot of " + ToString(i) + ", ";
                    break;
            }
        }

        Debug.Log(orderString);
        orderText.text = orderString; // asign to UI text element
        orderBox.color = Color.red;
        StartCoroutine(ClearOrderDisplay(12f)); // !! implement this as customer talking speed
    }
    IEnumerator ClearOrderDisplay(float delay)
    {
        yield return new WaitForSeconds(delay);
        orderText.text = "";
        orderBox.color = Color.clear;
        Debug.Log("Order text cleared");
    }
     private string ToString(int topping)
    {
        string[] toppingNames = { "sprinkles", "cookies", "cherries", "E&Es" };
        return toppingNames[topping];
    }
}

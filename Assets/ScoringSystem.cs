using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public float CalcScore(Customer customer, float timeHeld)
    {
        float maxPatience = customer.patience;
        float toppingMultiplier = CalcToppingScore(customer);
        float timeBonusMultiplier = CalcTimeScore(timeHeld, maxPatience);

        float score = 1 * toppingMultiplier * timeBonusMultiplier;

        return score;
    }

    private float CalcToppingScore(Customer customer)
    {
        GameObject cone = GameObject.FindGameObjectWithTag("IceCreamCone");
        int[] allToppings = {0, 0, 0, 0};
        float i = 0f;
        int correctToppings = 0;
        foreach(Transform topping in cone.transform)
        {
            //allToppings[i] = topping.gameObject;
            i+=1;
            int topID = GetToppingID(topping.gameObject.name);
            Debug.Log(topping.gameObject.name + ", ID: " + topID);
            if(topID > -1)
            {
                allToppings[topID] += 1;
                if(customer.order.toppingAmount[topID] > 0)
                {
                    correctToppings++;
                }
            }
        }

        return correctToppings/i;
    }

    private int GetToppingID(string name)
    {
        switch (name)
        {
            case "Cherry(Clone)":
                return 0;
            case "Cookie Chunk(Clone)":
                return 1;
            case "Sprinkle(Clone)":
                return 2;
            case "EandE(Clone)":
                return 3;
        }
        return -1;
    }

    private float CalcTimeScore(float timeHeld, float maxPatience)
    {
        float remainingPatience = Mathf.Clamp01(1f - timeHeld/ maxPatience);
        return 1f + remainingPatience;
    }
}

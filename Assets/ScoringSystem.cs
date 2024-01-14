using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public float CalcScore(Customer customer, float timeHeld, float maxPatience)
    {
        float toppingMultiplier = CalcToppingScore(customer);
        float timeBonusMultiplier = CalcTimeScore(timeHeld, maxPatience);

        float score = 1 * toppingMultiplier * timeBonusMultiplier;

        return score;
    }

    private float CalcToppingScore(Customer customer)
    {
        // !! to be implemented!!!
        return 0.5f;
    }

    private float CalcTimeScore(float timeHeld, float maxPatience)
    {
        float remainingPatience = Mathf.Clamp01(1f - timeHeld/ maxPatience);
        return 1f + remainingPatience;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToppingCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if (collision.gameObject.tag == "IceCreamCone")
        {
            transform.parent = collision.gameObject.transform;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}

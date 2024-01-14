using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinkleRandomColor : MonoBehaviour
{
    public Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.white };
    // Start is called before the first frame update
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        int i = Random.Range(0, colors.Length);
        rend.material.color = colors[i];
    }
}

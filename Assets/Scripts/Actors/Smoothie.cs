using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoothie : MonoBehaviour
{
    public Dictionary<string, Color> dict = new Dictionary<string, Color>() {
        {"carrot", new Color(0.3f, 0.2f, 0.1f)}
    };
    private SpriteRenderer sp;
    
    public void SetColor()
    {
        Debug.Log("hi");
        sp = GetComponent<SpriteRenderer>();
        sp.color = dict["carrot"];

    }
}

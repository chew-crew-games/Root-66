using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DraggableText : MonoBehaviour
{
    public GameObject follow;
    TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = follow.name;
        transform.position = follow.transform.position;
    }
}

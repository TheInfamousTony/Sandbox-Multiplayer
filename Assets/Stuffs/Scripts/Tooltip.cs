using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text nameText;
    public Text descText;

    void Update()
    {
        Vector2 position = Input.mousePosition;
        transform.position = position;
    }

    public void SetText(string desc, string name)
    {
        nameText.text = name;
        descText.text = desc;
    }
}
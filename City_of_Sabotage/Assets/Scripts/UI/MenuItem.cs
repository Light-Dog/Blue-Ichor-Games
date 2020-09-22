using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour
{
    public Color hoverColor;
    public Color baseColor;

    public Image background;

    // Start is called before the first frame update
    void Start()
    {
        background.color = baseColor;
        Debug.Log(background.color);
    }

    public void Select()
    {   
        background.color = hoverColor;
    }

    public void Deselect()
    {
        background.color = baseColor;
    }
}

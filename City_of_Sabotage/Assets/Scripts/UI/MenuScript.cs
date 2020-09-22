using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public Vector2 normalizedMousePos;
    public int selection;
    private int previousSelection = 0;

    public GameObject[] menuItems;

    private MenuItem previousWeapon;
    private MenuItem currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalizedMousePos = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        

        calculatePos();
        Debug.Log(selection);

        
        if(selection != previousSelection)
        {
            previousWeapon = menuItems[previousSelection].GetComponent<MenuItem>();
            previousWeapon.Deselect();

            previousSelection = selection;

            currentWeapon = menuItems[selection].GetComponent<MenuItem>();
            currentWeapon.Select();
        }
        
    }

    void calculatePos()
    {
        float angle = Mathf.Atan2(normalizedMousePos.y, normalizedMousePos.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        if (angle > 0 )
        {
            if (angle < 90)
                selection = 0;
            else
                selection = 3;
        }
        else
        {
            if (angle > -90)
                selection = 1;
            else
                selection = 2;
        }
        
    }

    public int GetCurrentWeapon()
    {
        return selection;
    }
}

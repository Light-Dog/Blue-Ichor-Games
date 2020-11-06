using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    int currentWeapon = 0;
    public GameObject hammer;
    public GameObject minigun;
    public GameObject cryogun;
    public GameObject windcannon;
    public GameObject bombglove;
    private float maxtimer = 1.5f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = 0;
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < maxtimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Swap();
            timer = 0.0f;
            if (currentWeapon < 4)
            {
                currentWeapon++;
            }
            else
            { 
                currentWeapon = 0;
            }
        }

    }

    void Swap()
    {
        if (currentWeapon == 0)
        {
            hammer.SetActive(true);
            minigun.SetActive(false);
            cryogun.SetActive(false);
            windcannon.SetActive(false);
            bombglove.SetActive(false);
        }
        if (currentWeapon == 1)
        {
            hammer.SetActive(false);
            minigun.SetActive(true);
            cryogun.SetActive(false);
            windcannon.SetActive(false);
            bombglove.SetActive(false);
        }
        if (currentWeapon == 2)
        {
            hammer.SetActive(false);
            minigun.SetActive(false);
            cryogun.SetActive(true);
            windcannon.SetActive(false);
            bombglove.SetActive(false);
        }
        if (currentWeapon == 3)
        {
            hammer.SetActive(false);
            minigun.SetActive(false);
            cryogun.SetActive(false);
            windcannon.SetActive(true);
            bombglove.SetActive(false);
        }
        if (currentWeapon == 4)
        {
            hammer.SetActive(false);
            minigun.SetActive(false);
            cryogun.SetActive(false);
            windcannon.SetActive(false);
            bombglove.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AmeliaStats>().gameObject;
        player.transform.position = this.gameObject.transform.position;
    }

    private void Update()
    {
        player.transform.position = this.gameObject.transform.position;
    }

}

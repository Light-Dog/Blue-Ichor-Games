using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMenu : MonoBehaviour
{
    public WeaponWheel data;
    public WheelPiece piecePrefeab;

    public float gapWidthDegree = 1.0f;

    protected WheelMenu Parent;
    protected WheelPiece[] pieces;

    
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void create(Transform player)
    {
        float stepLength = 360.0f / (float)data.elements.Length;

        pieces = new WheelPiece[data.elements.Length];
        for (int i = 0; i < data.elements.Length; i++)
        {
            pieces[i] = Instantiate(piecePrefeab, player);

            pieces[i].transform.localPosition = Vector3.zero;
            pieces[i].transform.localRotation = Quaternion.identity;

            //set pieces
            pieces[i].piece.fillAmount = 1.0f / (float)data.elements.Length - gapWidthDegree / 360.0f;
            pieces[i].piece.transform.localPosition = Vector3.zero;
            pieces[i].piece.transform.localRotation = Quaternion.identity;
            pieces[i].piece.color = new Color(1.0f, 1.0f, 1.0f, .5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class SimpleClock : MonoBehaviour
{
    public TMP_Text clockDisplayText;
    public TMP_Text dateDisplayText;
    Color m_textColor;

    void Start(){
        m_textColor = Color.white;
        clockDisplayText.color = m_textColor;
        dateDisplayText.color = m_textColor;
    }

    // Update is called once per frame
    void Update()
    {
        DateTime rightNow = DateTime.Now;
        clockDisplayText.text = rightNow.ToString("t");
        dateDisplayText.text = rightNow.ToString("dddd MM/dd/yyyy");

    }

    public void ToggleColor(){
        if(m_textColor == Color.white){
            clockDisplayText.color = Color.black;
            dateDisplayText.color = Color.black;
            m_textColor = Color.black;
        } else {
            clockDisplayText.color = Color.white;
            dateDisplayText.color = Color.white;
            m_textColor = Color.white;
        }

    }

}

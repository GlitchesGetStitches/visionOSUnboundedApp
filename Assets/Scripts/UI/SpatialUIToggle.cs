//Based on the Spatial UI system packaged with the PolySpatial samples. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class ToggleUI3D : SpatialUI
{
    public bool active => m_active;
    bool m_active;

    [SerializeField]
    Transform m_ToggleButton;

    [SerializeField]
    MeshRenderer m_ToggleBackground;

    Vector3 m_ButtonOnTargetPosition;
    Vector3 m_ButtonOffTargetPosition;

    float m_StartLerpTime;

    public UnityEvent toggleEvent;

    const float k_ButtonOnPosition = -0.05f;
    const float k_ButtonOffPosition = 0.05f;
    const float k_lerpSpeed = 3.0f;

    void Start(){
        var buttonPosition = m_ToggleButton.localPosition;
        m_ButtonOnTargetPosition = new Vector3(k_ButtonOnPosition, buttonPosition.y, buttonPosition.z);
        m_ButtonOffTargetPosition = new Vector3(k_ButtonOffPosition, buttonPosition.y, buttonPosition.z);
    }

    void Update(){
        var coveredAmount = (Time.time - m_StartLerpTime) * k_lerpSpeed;
        var lerpPercentage = coveredAmount / (k_ButtonOffPosition * 2);
        m_ToggleButton.localPosition = Vector3.Lerp(m_active ? m_ButtonOffTargetPosition : m_ButtonOnTargetPosition,
            m_active ? m_ButtonOnTargetPosition : m_ButtonOffTargetPosition, lerpPercentage);
    }

    public override void Press(Vector3 position){
        base.Press(position);
        m_active = !m_active;

        m_StartLerpTime = Time.time;
        m_ToggleBackground.material.color = m_active ? SelectedColor : UnselectedColor;
        
        toggleEvent.Invoke();
    }
}

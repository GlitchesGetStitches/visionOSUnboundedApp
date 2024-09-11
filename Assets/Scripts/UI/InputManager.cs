using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    InputActionReference m_Touch;

    void OnEnable(){
        EnhancedTouchSupport.Enable();
        m_Touch.action.Enable();
    }

    void Update(){
        ProcessInput();
    }

    void ProcessInput(){

        var touchData = m_Touch.action.ReadValue<SpatialPointerState>();
        var activeTouches = Touch.activeTouches;
        if(activeTouches.Count > 0){

            var primaryTouchPhase = activeTouches[0].phase;
            if(primaryTouchPhase == UnityEngine.InputSystem.TouchPhase.Began){

                var buttonObject = touchData.targetObject;
                if(buttonObject != null){

                    if(buttonObject.TryGetComponent(out SpatialUI button)){

                        button.Press(touchData.interactionPosition);
                    }
                }  
            }
        }
    }

}

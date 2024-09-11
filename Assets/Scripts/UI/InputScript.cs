// script based on PolySpatial documentation examples
// https://docs.unity3d.com/Packages/com.unity.polyspatial.visionos@1.0/manual/PolySpatialInput.html
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;


public class InputScript : MonoBehaviour
{
    GameObject m_SelectedObject;
    [SerializeField]
    InputActionReference m_TouchPrimary;

    void OnEnable(){
        EnhancedTouchSupport.Enable();
        m_TouchPrimary.action.Enable();
    }

    void Update()
    {
        var activeTouches = Touch.activeTouches;

        if (activeTouches.Count > 0)
        {
            SpatialPointerState primaryTouchData = m_TouchPrimary.action.ReadValue<SpatialPointerState>();

            //Primary SpatialPointer functionality
            if (activeTouches[0].phase == TouchPhase.Began)
            {
                // if the targetObject is not null, set it to the selected object
                m_SelectedObject = primaryTouchData.targetObject != null ? primaryTouchData.targetObject : null;
            }

            if (activeTouches[0].phase == TouchPhase.Moved)
            {
                if (m_SelectedObject != null)
                {
                    // This line effectively "picks up" pieces of furniture, allowing us to lift and rotate. We don't want this behavior, so...
                    //m_SelectedObject.transform.SetPositionAndRotation(primaryTouchData.interactionPosition, primaryTouchData.inputDeviceRotation);

                    // We can use this line to translate selected pieces of furniture (gameobjects with a collider) along the floor, or the X and Z axes.
                    m_SelectedObject.transform.SetPositionAndRotation(new Vector3(primaryTouchData.interactionPosition.x, 0, primaryTouchData.interactionPosition.z), m_SelectedObject.transform.rotation);
                }
            }

            if(activeTouches[0].phase == TouchPhase.Ended || activeTouches[0].phase == TouchPhase.Canceled)
            {
                m_SelectedObject = null;
            }


            // Secondary SpatialPointer functionality
            // Here, whenever more than one SpatialPointer input is detected, we rotate the selected gameobject 90 degrees on the Y axis.
            if(activeTouches.Count > 1 && m_SelectedObject != null && activeTouches[1].phase == TouchPhase.Began){
                m_SelectedObject.transform.Rotate(0, 90, 0);
            }
        }
    }
}
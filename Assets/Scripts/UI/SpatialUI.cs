using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialUI : MonoBehaviour
{
    public Color SelectedColor = new Color(0.88f, 0.88f, 0.88f, 1.0f);
    public Color UnselectedColor = new Color(0.22f, 0.22f, 0.22f, 1.0f);
    public virtual void Press(Vector3 position){
        
    }
}

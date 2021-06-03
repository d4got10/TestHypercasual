using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchListener : MonoBehaviour
{
    public UnityEvent<Vector2> Tapped;

    private bool _tapped;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Tapped.Invoke(Input.mousePosition);
        }
#else
        if(Input.touchCount > 0)
        {
            if (_tapped == false)
            {
                _tapped = true;
                var touch = Input.GetTouch(0);
                Tapped.Invoke(touch.position);
            }
        }
        else
        {
            _tapped = false;
        }
#endif
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public delegate void TouchEventHandler(TouchWrapper touchWrapper);

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    Dictionary<int, TouchWrapper> touches = new Dictionary<int, TouchWrapper>();

    private event TouchEventHandler TouchListener;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touches.ContainsKey(touch.fingerId) == false)
            {
                touches.Add(touch.fingerId, new TouchWrapper(touch));
                if(TouchListener != null)
                {
                    TouchListener.Invoke(touches[touch.fingerId]);
                }
            }
            touches[touch.fingerId].UpdateTouch(touch);
        }
    }

    public void Subscribe(TouchEventHandler touchListener)
    {
        TouchListener += touchListener;
    }

    public void Unsubscribe(TouchEventHandler touchListener)
    {
        TouchListener -= touchListener;
    }
}

public class TouchWrapper
{
    public Touchable clicked;
    public Touch touch;

    public TouchWrapper(Touch touch)
    {
        this.touch = touch;
    }

    public void UpdateTouch(Touch touch)
    {
        if(this.touch.fingerId != touch.fingerId)
        {
            return;
        }
        this.touch = touch;

        switch (touch.phase)
        {
            case TouchPhase.Began:
                GetGameObject();
                clicked.OnTouchDown(touch);
                break;

            case TouchPhase.Stationary:
            case TouchPhase.Moved:
                clicked.OnTouchDrag(touch);
                break;

            case TouchPhase.Canceled:
            case TouchPhase.Ended:
                clicked.OnTouchUp(touch);
                break;
        }
    }

    private Touchable GetGameObject()
    {
        if(clicked == null)
        {
            RaycastHit2D hit = Physics2D.Raycast(touch.position, Vector2.zero, 0f);
            if (hit)
            {
                Debug.Log("touched["+touch.fingerId+"]: " + hit.transform.name);
                clicked = hit.transform.gameObject.GetComponent<Touchable>();
            }
        }
        return clicked;
    }
}

public interface Touchable
{
    void OnTouchDown(Touch touch);
    void OnTouchDrag(Touch touch);
    void OnTouchUp(Touch touch);
}
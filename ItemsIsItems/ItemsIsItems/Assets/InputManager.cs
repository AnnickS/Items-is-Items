using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
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

public delegate void TouchUpdateEventHandler(Touch touch);

public class TouchWrapper
{
    public Touch touch;

    private event TouchUpdateEventHandler OnTouchStart;
    private event TouchUpdateEventHandler OnTouchDrag;
    private event TouchUpdateEventHandler OnTouchEnd;

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
                if (OnTouchStart != null)
                {
                    OnTouchStart.Invoke(touch);
                }
                break;
            //case TouchPhase.Stationary:
            case TouchPhase.Moved:
                if (OnTouchDrag != null)
                {
                    OnTouchDrag.Invoke(touch);
                }
                break;
            case TouchPhase.Canceled:
            case TouchPhase.Ended:
                if (OnTouchEnd != null)
                {
                    OnTouchEnd.Invoke(touch);
                }
                break;
        }
    }
}

    */
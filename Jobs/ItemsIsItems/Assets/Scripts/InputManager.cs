using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    Dictionary<int, UnityEvent> touches = new Dictionary<int, UnityEvent>();

    public UnityTouchEvent OnTouch = new UnityTouchEvent();

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    AddTouch(Input.GetTouch(i));                    
                    break;
                case TouchPhase.Canceled:
                case TouchPhase.Ended:
                    RemoveTouch(touch);
                    break;
            }
        }
    }

    private void RemoveTouch(Touch touch)
    {
        if(touches[touch.fingerId] != null)
        {
            touches[touch.fingerId].Invoke();
        }
        touches.Remove(touch.fingerId);
    }

    private void AddTouch(Touch touch)
    {
        if (touches.ContainsKey(touch.fingerId) == false)
        {
            touches.Add(touch.fingerId, new UnityEvent());
        }

        if (OnTouch != null)
        {
            OnTouch.Invoke(touch);
        }
    }

    public Touch? GetTouch(int touchID)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).fingerId == touchID)
            {
                return Input.GetTouch(i);
            }
        }
        return null;
    }

    public bool OnTouchEnd(int touchID, UnityAction action)
    {
        if (touches.ContainsKey(touchID))
        {
            touches[touchID].AddListener(action);
            Debug.Log("Listening");
            return true;
        }
        return false;
    }

}

[Serializable]
public class UnityTouchEvent : UnityEvent<Touch> { }


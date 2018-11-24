using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    
    Dictionary<int, UnityTouchEvent> touches = new Dictionary<int, UnityTouchEvent>();

    public UnityTouchEvent OnTouchDown = new UnityTouchEvent();
    //public UnityTouchEvent OnTouchUp = new UnityTouchEvent();

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
            touches[touch.fingerId].Invoke(touch);
        }
        touches.Remove(touch.fingerId);
    }

    private void AddTouch(Touch touch)
    {
        if (touches.ContainsKey(touch.fingerId) == false)
        {
            touches.Add(touch.fingerId, new UnityTouchEvent());
        }

        if (OnTouchDown != null)
        {
            OnTouchDown.Invoke(touch);
        }
        /*
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            switch (LayerMask.LayerToName(hit.collider.gameObject.layer))
            {
                case "Item":
                    Item item = hit.transform.GetComponent<Item>();
                    if (Contains(item))
                    {
                        selectedItems.Add(touch.fingerId, item);
                        //RemoveItem(item);
                        //hit.transform.GetComponent<Movement>().SetTargetPosition(touch);
                    }
                    break;
            }
        }*/
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

    public bool OnTouchEnd(int touchID, UnityAction<Touch> action)
    {
        if (touches.ContainsKey(touchID))
        {
            touches[touchID].AddListener(action);
            return true;
        }
        return false;
    }

}

[Serializable]
public class UnityTouchEvent : UnityEvent<Touch> { }


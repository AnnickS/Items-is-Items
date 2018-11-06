
using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour {

    public Button button;
    public Image image;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(ButtonPressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ButtonPressed()
    {
        Selected selected = Selected.getInstance();
        Debug.Log("Hi");

        if(selected.isItemSelected())
        {
            Debug.Log("bye");

            Pickup item = selected.getSelectedItem();
            image.sprite = item.GetComponent<SpriteRenderer>().sprite;
            image.enabled = true;

            selected.deselect();
        }
    }
}

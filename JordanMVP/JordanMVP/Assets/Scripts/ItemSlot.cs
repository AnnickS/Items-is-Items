
using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour {

    protected static ItemSlot selectedItemSlot;

    public static Pickup getSelectedItem()
    {
        return selectedItemSlot.item;
    }

    public static bool isItemSelected()
    {
        if(selectedItemSlot == null)
        {
            return false;
        }
        else
        {
            return selectedItemSlot.item != null;
        }

    }

    public static void deselect()
    {
        selectedItemSlot.image.color = Color.white;
        selectedItemSlot.item.gameObject.SetActive(true);
        setColorOfItem(selectedItemSlot.item, Color.white);
        selectedItemSlot.image.color = Color.clear;
        selectedItemSlot.item = null;
    }

    private static void setColorOfItem(Pickup item, Color color)
    {
        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }



    public Button button;
    public Image image;
    private Pickup item;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(ButtonPressed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ButtonPressed()
    {
        Debug.Log("button presesed");
        Selected selected = Selected.getInstance();

        if(item != null)
        {
            selectedItemSlot = this;
        }
        else if(selected.isItemSelected())
        {

            Pickup item = selected.getSelectedItem();
            image.enabled = true;
            image.color = Color.white;
            image.sprite = item.GetComponent<SpriteRenderer>().sprite;
            item.gameObject.SetActive(false);
            this.item = item;

            selected.deselect();
        }
    }
}

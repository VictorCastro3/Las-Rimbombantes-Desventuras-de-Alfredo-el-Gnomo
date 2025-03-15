using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    public DragAndDrop[] dd;
    [SerializeField]
    private GameObject item;
    [SerializeField]
    private UIManager ui; // The UIManager component
    [SerializeField]
    private Image BoxImage; // The box image
    [SerializeField]
    private Sprite[] ItemBoxSprites; // The item box sprites
    [SerializeField]
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        ui=FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active()
    {
        active = true;
    }
    public bool IsActive()
    {
        return active;
    }
    public void UpdateSprite()
    {
        if (active)
        {
            BoxImage.sprite = ItemBoxSprites[1];
        }
       
    }
    public void GetItem()
    {
        if (active)
        {
            GameObject parentObject = dd[0].gameObject.transform.parent.gameObject;
            bool wasActive = parentObject.activeSelf;

            if (!wasActive)
            {
                parentObject.SetActive(true);
            }

            foreach (var dragAndDrop in dd)
            {
                if (dragAndDrop.prefab == null)
                {
                    dragAndDrop.prefab = item;
                    break; // Exit the loop after assigning the item to the first available DragAndDrop instance
                }
            }

            if (!wasActive)
            {
                parentObject.SetActive(false);
            }
        }      
    }
}

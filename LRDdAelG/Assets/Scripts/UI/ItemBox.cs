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
    private GameObject itemImg;
    [SerializeField]
    private UIManager ui; // The UIManager component
    [SerializeField]
    private Image BoxImage; // The box image
    [SerializeField]
    private Sprite[] ItemBoxSprites; // The item box sprites
    [SerializeField]
    private Sprite[] ItemImages;
    [SerializeField]
    private bool active = false;
    [SerializeField]
    private bool Bumper = false;
    [SerializeField]
    private bool Cannon = false;
    [SerializeField]
    private bool Cloud = false;
    [SerializeField]
    private bool Fan = false;
    [SerializeField]
    private bool Mov = false;
    [SerializeField]
    private bool Stop = false;
    [SerializeField]
    private bool Rev = false;
    [SerializeField]
    private bool Tramp = false;
    [SerializeField]
    private bool Button = false;
    [SerializeField]
    public GameObject itemBox;

    private Image itemImage;
    // Start is called before the first frame update
    void Start()
    {
        ui=FindObjectOfType<UIManager>();
        if (!active)
        {
            itemImg.SetActive(false);
            itemImage = itemBox.GetComponent<Image>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Active(bool act)
    {
        active = act;
    }
    public bool IsActive()
    {
        return active;
    }
    public void UpdateSprite(bool revert)
    {
        if (active)
        {
            BoxImage.sprite = ItemBoxSprites[1];
            itemImg.SetActive(true);
        }
        if (revert)
        {
            BoxImage.sprite = ItemBoxSprites[0];
            itemImg.SetActive(false);
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
                    if (Bumper) dragAndDrop.itemImage = ItemImages[0];
                    else if (Cannon)
                    {
                        dragAndDrop.itemImage = ItemImages[1];
                        itemImage.sprite = ItemImages[1];
                    }
                    else if (Cloud)
                    {
                        dragAndDrop.itemImage = ItemImages[2];
                        itemImage.sprite = ItemImages[2];
                    }
                    else if (Fan)
                    {
                        dragAndDrop.itemImage = ItemImages[3];
                        itemImage.sprite = ItemImages[3];
                    }
                    else if (Mov)
                    {
                        dragAndDrop.itemImage = ItemImages[4];
                        itemImage.sprite = ItemImages[4];
                    }
                    else if (Stop)
                    {
                        dragAndDrop.itemImage = ItemImages[5];
                        itemImage.sprite = ItemImages[5];
                    }
                    else if (Rev)
                    {
                        dragAndDrop.itemImage = ItemImages[6];
                        itemImage.sprite = ItemImages[6];
                    }
                    else if (Tramp)
                    {
                        dragAndDrop.itemImage = ItemImages[7];
                        itemImage.sprite = ItemImages[7];
                    }
                    else if (Button)
                    {
                        dragAndDrop.itemImage = ItemImages[8];
                        itemImage.sprite = ItemImages[8];
                    }
                    break; // Exit the loop after assigning the item to the first available DragAndDrop instance
                }
            }

            if (!wasActive)
            {
                parentObject.SetActive(false);
            }
        }      
    }
    public void SetItemImage()
    {

    }
}

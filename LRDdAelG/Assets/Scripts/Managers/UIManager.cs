using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;


public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject ChooseObj;
    [SerializeField]
    private GameObject Inventory;
    [SerializeField]
    private ItemBox[] itemBoxes;
    [SerializeField]
    private Image itemBoxImage;
    [SerializeField]
    private bool top = false;
    [SerializeField]
    private bool bottom = false;
    [SerializeField]
    private bool first = true;
    [SerializeField]
    private bool last = false;
    [SerializeField]
    private bool toptop = false;
    [SerializeField]
    private bool bottombottom = false;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.SetActive(false);
        itemBoxes[0].UpdateSprite();
        //GameManager.Instance.GiveUI(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChooseItem()
    {
        RevealBox();
    }
    private void EndChoose()
    {
        Inventory.SetActive(true);
        ChooseObj.SetActive(false);
       
    }
    public void Top()
    {
        if(itemBoxes[1].IsActive()) top = true;

    }
    public void Bottom()
    {
        if (itemBoxes[2].IsActive()) bottom = true;
    }
    public void Last()
    {
        if (itemBoxes[5].IsActive()|| itemBoxes[6].IsActive()|| itemBoxes[3].IsActive()|| itemBoxes[4].IsActive()) last = true;
    }
    public void First()
    {
        first = true;
    }
    public void TopTop()
    {
        if(top) toptop = true;
        top = false;
    }
    public void BottomBottom()
    {
        if(bottom) bottombottom=true;
        bottom = false;
    }
    public bool IsTopTop()
    {
        return toptop;
    }
    public bool IsBottomBottom()
    {
        return bottombottom;
    }
    private void RevealBox()
    {
        if (top)
        {
            if (itemBoxes[1].IsActive() || itemBoxes[2].IsActive())
            {
                itemBoxes[5].Active();
                itemBoxes[6].Active();
                itemBoxes[5].UpdateSprite();
                itemBoxes[6].UpdateSprite();
            }
           
        }
        else if (bottom)
        {
            if (itemBoxes[1].IsActive()|| itemBoxes[2].IsActive())
            {
                itemBoxes[3].Active();
                itemBoxes[4].Active();
                itemBoxes[3].UpdateSprite();
                itemBoxes[4].UpdateSprite();
            }            
        }
        else if (first)
        {
            if (!itemBoxes[1].IsActive()&& !itemBoxes[2].IsActive()&& !itemBoxes[3].IsActive()&& !itemBoxes[4].IsActive()&& !itemBoxes[5].IsActive()&& !itemBoxes[6].IsActive())
            {
                itemBoxes[1].Active();
                itemBoxes[2].Active();
                itemBoxes[1].UpdateSprite();
                itemBoxes[2].UpdateSprite();
                first = false;
            }
           
        }
        else if(last)
        {
            if (itemBoxes[5].IsActive() && IsTopTop() || itemBoxes[6].IsActive() && IsTopTop() || itemBoxes[3].IsActive() && IsBottomBottom() || itemBoxes[4].IsActive() && IsBottomBottom()) 
            {
                EndChoose();
            }
           
        }
    }
   
}

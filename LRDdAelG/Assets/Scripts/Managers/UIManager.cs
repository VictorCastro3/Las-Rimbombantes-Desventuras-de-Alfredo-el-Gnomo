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
    private ItemBox[] itemBoxes;
    [SerializeField]
    private Image itemBoxImage;
    [SerializeField]
    private bool chooseFase = true;
    [SerializeField]
    private bool top = false;
    [SerializeField]
    private bool bottom = false;
    [SerializeField]
    private bool first = true;
    [SerializeField]
    private bool last = false;

    // Start is called before the first frame update
    void Start()
    {
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
        ChooseObj.SetActive(false);
    }
    public void Top()
    {
        top = true;
    }
    public void Bottom()
    {
        bottom = true;
    }
    public void Last()
    {
        last = true;
    }
    private void RevealBox()
    {
        if (top)
        {
            itemBoxes[5].UpdateSprite();
            itemBoxes[6].UpdateSprite();
            top = false;
        }
        else if (bottom)
        {
            itemBoxes[3].UpdateSprite();
            itemBoxes[4].UpdateSprite();
            bottom= false;
        }
        else if (first)
        {
            itemBoxes[1].UpdateSprite();
            itemBoxes[2].UpdateSprite();
            first = false;
        }
        else if(last)
        {
            EndChoose();
        }
    }
   
}

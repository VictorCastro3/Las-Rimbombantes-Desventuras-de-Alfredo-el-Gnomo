using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public DragAndDrop[] dd;
    [SerializeField]
    private GameObject ChooseObj;
    [SerializeField]
    private GameObject Inventory;
    [SerializeField]
    private ItemBox[] itemBoxes;
    [SerializeField]
    private Subtitles sub;
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


    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.SetActive(false);
        ChooseObj.SetActive(true);
        itemBoxes[0].UpdateSprite(false);
        sub=GetComponent<Subtitles>();
        //GameManager.Instance.GiveUI(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }
    public void ChooseItem()
    {
        RevealBox();
    }
    private void EndChoose()
    {
        Inventory.SetActive(true);
        ChooseObj.SetActive(false);
        firstTime = false;
    }
    public bool PlayFirst()
    {
        return firstTime;
    }
    public void Top()
    {
        if(itemBoxes[1].IsActive()&&!bottom) top = true;

    }
    public void Bottom()
    {
        if (itemBoxes[2].IsActive()&&!top) bottom = true;
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
                itemBoxes[5].Active(true);
                itemBoxes[6].Active(true);
                itemBoxes[5].UpdateSprite(false);
                itemBoxes[6].UpdateSprite(false);
            }
           
        }
        else if (bottom)
        {
            if (itemBoxes[1].IsActive()|| itemBoxes[2].IsActive())
            {
                itemBoxes[3].Active(true);
                itemBoxes[4].Active(true);
                itemBoxes[3].UpdateSprite(false);
                itemBoxes[4].UpdateSprite(false);
            }            
        }
        else if (first)
        {
            if (!itemBoxes[1].IsActive()&& !itemBoxes[2].IsActive()&& !itemBoxes[3].IsActive()&& !itemBoxes[4].IsActive()&& !itemBoxes[5].IsActive()&& !itemBoxes[6].IsActive())
            {
                itemBoxes[1].Active(true);
                itemBoxes[2].Active(true);
                itemBoxes[1].UpdateSprite(false);
                itemBoxes[2].UpdateSprite(false);
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
    public void RevertToChoose()
    {
        Inventory.SetActive(false);
        ChooseObj.SetActive(true);
        for(int i = 0; i < itemBoxes.Length; i++)
        {
            itemBoxes[i].Active(false);
            itemBoxes[i].UpdateSprite(true);
        }
        itemBoxes[0].Active(true);
        itemBoxes[0].UpdateSprite(false);
        for(int i = 0;i<dd.Length; i++)
        {
            dd[i].prefab = null;
        }
        PlayerMovement player = GameManager.Instance.GetPlayer().GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.Restart();
        }
        
    }
   
}

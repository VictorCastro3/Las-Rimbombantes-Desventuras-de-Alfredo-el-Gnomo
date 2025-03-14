using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    [SerializeField]
    private UIManager ui; // The UIManager component
    [SerializeField]
    private Image BoxImage; // The box image
    [SerializeField]
    private Sprite[] ItemBoxSprites; // The item box sprites
    // Start is called before the first frame update
    void Start()
    {
        ui=FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSprite()
    {
        BoxImage.sprite = ItemBoxSprites[1];
    }
}

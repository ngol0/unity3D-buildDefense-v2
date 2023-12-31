using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    InteractableData data;
    Shop shop;

    [SerializeField] Image spriteImg;
    [SerializeField] Button btn;
    [SerializeField] Text nameText;

    public void SetData(InteractableData data, Shop shop)
    {
        this.data = data;
        this.shop = shop;
        SetUI();
    }

    private void SetUI()
    {
        spriteImg.sprite = data.sprite;
        nameText.text = data.nameString;
    }

    public void OnShopItemClicked()
    {
        shop.OnTransaction(data);
    }

    public void SetBtnActive(bool active)
    {
        btn.interactable = active;
    }
}

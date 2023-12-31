using UnityEngine.UI;
using UnityEngine;

public class PlaceableButtonUI : MonoBehaviour
{
    [Header("UI Ref")]
    [SerializeField] Image icon;
    [SerializeField] Image selectedBG;
    [SerializeField] Image overlayBG;
    [SerializeField] Button btn;
    [SerializeField] Text nameText;

    LoadingItem loading;

    float lockInteraction = 1f;

    InteractableData itemData;
    public InteractableData ItemData => itemData;
    bool isSelected = false;

    private void Awake() 
    {
        SetOverlayBG(lockInteraction);   
    }

    private void Update() 
    {
        overlayBG.fillAmount = loading.GetRemainingTime(this);
    }

    public void SetOverlayBG(float value)
    {
        overlayBG.fillAmount = value;
    }

    public void SetData(InteractableData itemData, LoadingItem loading)
    {
        this.itemData = itemData;
        this.loading = loading;
        SetButtonUI();
    }

    public void SetButtonUI()
    {
        icon.sprite = itemData.sprite;
        nameText.text = itemData.nameString;
        selectedBG.enabled = false;
    }

    public void SetSelectedActive(bool active)
    {
        selectedBG.enabled = active;
        isSelected = active;
    }

    public void SetBtnInteractive(bool active)
    {
        btn.interactable = active;
    }
}

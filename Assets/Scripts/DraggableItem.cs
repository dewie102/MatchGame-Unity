using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemData itemData;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    public ItemSlot originSlot;
    public bool droppedOnSlot;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        droppedOnSlot = false;
        originSlot = GetComponentInParent<ItemSlot>();
        Debug.Log($"What am I? {gameObject}\n originSlot: {originSlot}\nParent: {transform.parent.gameObject}");
        originalParent = transform.parent;
        transform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!droppedOnSlot)
        {
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
        }
        canvasGroup.blocksRaycasts = true;
    }

    public void SetItemData(ItemData data)
    {
        itemData = data;
        GetComponent<Image>().sprite = data.icon;
    }
}

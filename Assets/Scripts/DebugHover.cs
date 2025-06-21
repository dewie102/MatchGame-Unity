using UnityEngine;
using UnityEngine.EventSystems;

public class DebugHover : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered " + gameObject.name);
    }
}

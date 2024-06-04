using UnityEngine;
using UnityEngine.EventSystems;

public class scrollClose : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), eventData.position))
        {
            gameObject.SetActive(false);
        }
    }
}

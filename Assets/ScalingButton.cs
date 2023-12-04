using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScalingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool hoverAnimation = false;
    Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);
    Vector3 normalScale = Vector3.one;
    [SerializeField] private float scalingTime = 3f;
    private void Update()
    {
        if (hoverAnimation)
        {
            transform.localScale = Vector3.Slerp(transform.localScale, targetScale, scalingTime * Time.deltaTime);
        }
        else
        {
            transform.localScale = Vector3.Slerp(transform.localScale, normalScale, scalingTime * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverAnimation = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverAnimation = false;
    }
}

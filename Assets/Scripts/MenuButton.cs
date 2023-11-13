using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Sprite oldSprite;
    public Sprite newSprite;
    private Image image;
    private AudioSource audioSource;
    [SerializeField] bool musicButton = false;

    private void Start()
    {
        image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        oldSprite = image.sprite;
    }

    // This function will be called when the button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        if (image.sprite == oldSprite && musicButton) { image.sprite = newSprite; }
        else if (image.sprite == newSprite && musicButton) { image.sprite = oldSprite; }
        if (!musicButton)
        {
            image.sprite = oldSprite;
            image.sprite = newSprite;
        }
        audioSource.Play();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!musicButton)
        {
            image.sprite = oldSprite;
        }
        
    }
}

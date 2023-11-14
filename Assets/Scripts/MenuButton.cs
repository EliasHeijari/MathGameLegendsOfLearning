using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Sprite oldSprite;
    public Sprite newSprite;
    private Image image;
    private AudioSource audioSource;
    [SerializeField] bool musicButton = false;
    [SerializeField] private Material redMat;
    private Material oldMat;
    float newZ = -50f;
    Vector3 targetPos;
    Vector3 oldPos;
    bool hoverAnimation = false;
    [SerializeField] private float fillSpeed = 5f;
    

    private void Start()
    {
        image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        oldMat = image.material;
        oldSprite = image.sprite;
        targetPos = transform.position + Vector3.forward * newZ;
        oldPos = transform.position;
        image.fillAmount = 0;
    }

    private void Update()
    {
        if (hoverAnimation)
        {
            if (transform.position != targetPos)
            {
                image.fillAmount = Mathf.MoveTowards(image.fillAmount, 1, fillSpeed * Time.deltaTime);
                transform.position = Vector3.Slerp(transform.position, targetPos, 3f * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position != oldPos)
            {
                image.fillAmount = Mathf.MoveTowards(image.fillAmount, 0, fillSpeed * Time.deltaTime); ;
                transform.position = Vector3.Slerp(transform.position, oldPos, 3f * Time.deltaTime);
            }
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

    // This function will be called when the button is pressed
    public void OnPointerDown(PointerEventData eventData)
    {
        if (image.sprite == oldSprite && musicButton) { image.sprite = newSprite; image.material = redMat; }
        else if (image.sprite == newSprite && musicButton) { image.sprite = oldSprite; image.material = oldMat; }
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

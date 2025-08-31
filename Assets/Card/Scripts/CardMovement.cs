using CardScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR.Haptics;
using DG.Tweening;
using System;
public class CardMovement : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalLocalPointerPosition;
    private Vector3 originalScale;
    public GameObject CardDescription;


    public int currretState = 0;

    private Quaternion originalRotation;

    private Vector3 originalPosition;

    [SerializeField] private float selectScale = 1.2f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private GameObject glowEffect;
    public GameObject CardSlot;

    public CardDisplay cardDisplay;

    public bool isGlowing = false;
    public bool isDestroyed = false;


    public float offset;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalScale = rectTransform.localScale;
        originalRotation = rectTransform.localRotation;
        originalPosition = rectTransform.localPosition;
        CardDisplay cardDisplay = GetComponent<CardDisplay>();
    }
    void Update()
    {
        switch (currretState)
        {
            case 0:
                TransitionToState0();
                break;
            case 1: //Hovering
                HandleHoverState();
                break;
            case 2: //Dragging
                CardDescription.SetActive(false);
                break;
            case 3: //Playing
                HandleSelectedState();
                break;
        }
        if (currretState == 0)
        {
            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, new Vector3(0f, 0f, 0f), 50f  * Time.deltaTime);
            transform.DOScale(1, 0.15f).SetEase(Ease.OutBack);
            glowEffect.SetActive(false);
            rectTransform.localRotation = originalRotation;
            CardDescription.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currretState == 0)
        {
            originalPosition = rectTransform.localPosition;
            originalRotation = rectTransform.localRotation;
            originalScale = rectTransform.localScale;

            currretState = 1;
            DOTween.Kill(2, true);
            transform.DOPunchRotation(Vector3.forward * 5, 0.3f, 20, 1).SetId(2);

        }
    }
    private void HandleHoverState()
    {
        if (rectTransform.localPosition == new Vector3(0f, 0f, 0f))
        {
            glowEffect.SetActive(true);
            CardDescription.SetActive(true);
            transform.DOScale(1.15f, 0.15f).SetEase(Ease.OutBack);

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currretState == 1)
        {
            transform.DOScale(1, 0.15f).SetEase(Ease.OutBack);
            TransitionToState0();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition / canvas.scaleFactor;
        currretState = 2;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        currretState = 0;
    }
    public void OnDrag(PointerEventData eventData)
    {
        currretState = 2;
        rectTransform.position = Vector3.Lerp(rectTransform.position, Input.mousePosition, 0.1f);
    }


    private void TransitionToState0()
    {
        currretState = 0;
        rectTransform.localScale = originalScale;
        rectTransform.localRotation = originalRotation;
        rectTransform.localPosition = originalPosition;
        glowEffect.SetActive(false);
        CardDescription.SetActive(false);
        transform.DOScale(1, 0.15f).SetEase(Ease.OutBack);
    }

   

    private void RemoveCard()
    {
        DiscardManager discardManager = FindFirstObjectByType<DiscardManager>();
        discardManager.AddToDiscard(GetComponent<CardDisplay>().carddata);
        HandManager handManager = FindFirstObjectByType<HandManager>();
        handManager.handCards.Remove(CardSlot);
        handManager.UpdateHandVisuals();
        Destroy(CardSlot);
    }


    private void useCard()
    {
        CardDisplay CardData = GetComponent<CardDisplay>();
        CardData.carddata.UseCard();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currretState == 1 || currretState == 0)
        {
            currretState = 3;
        }
    }
    public void HandleSelectedState()
    {
        useCard();
        RemoveCard();
    }
}

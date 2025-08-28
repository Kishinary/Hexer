using CardScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR.Haptics;
public class CardMovement : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerUpHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalLocalPointerPosition;
    private Vector3 originalScale;

    private int currretState = 0;

    private Quaternion originalRotation;

    private Vector3 originalPosition;

    [SerializeField] private float selectScale = 1.2f;
    [SerializeField] private Vector2 cardPlay;
    [SerializeField] private GameObject glowEffect;
    public GameObject CardSlot;



    public bool isDragging = false;
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
    }
    void Update()
    {
        if (currretState == 1)
        {
            HandleHoverState();
        }
        if (isDragging == false)
        {
            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, new Vector3(0f, 0f, 0f), 0.075f);
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
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currretState == 1 && isDragging == false)
        {
            TransitionToState0();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isGlowing == true && isDragging == false)
        {
            useCard();
            RemoveCard();

        }
    }
    private void HandleHoverState()
    {
        if (!isDragging && rectTransform.localPosition == new Vector3(0f, 0f, 0f))
        {
            glowEffect.SetActive(true);
            isGlowing = true;
        }
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







    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition / canvas.scaleFactor;
        isDragging = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        rectTransform.position= Vector3.Lerp(rectTransform.position, Input.mousePosition, 0.1f);
    }


    private void TransitionToState0()
    {
        currretState = 0;
        rectTransform.localScale = originalScale;
        rectTransform.localRotation = originalRotation;
        rectTransform.localPosition = originalPosition;
        glowEffect.SetActive(false);
    }
}

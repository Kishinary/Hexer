
using UnityEngine;

public class CardVisual : MonoBehaviour
{
    public CardMovement parentCard;
    private float curveYOffset;

    public float followSpeed = 5f;

    public HandManager HandManager;

    [SerializeField] private float rotationAmount = 20;
    [SerializeField] private float rotationSpeed = 20;
    [SerializeField] private float autoTiltAmount = 30;
    [SerializeField] private float manualTiltAmount = 20;
    [SerializeField] private float tiltSpeed = 20;



    private float curveRotationOffset;


    private int savedIndex;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CardVisualFollow()
    {

        this.transform.position = Vector3.MoveTowards(transform.position, parentCard.transform.position, 0.01f);
    }
}

using UnityEngine;
using CardScripts;
using System.Collections.Generic;
using System.Collections;
public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab; // assign the card prefab in the inspector
    public Transform handTransform; // Hand position in the scene
    public float fanspread = 5f;
   
    public float cardspacing = 5f; // Adjust this value to change the spacing between cards
    public List<GameObject> handCards = new List<GameObject>();
    void Start()
    {
        Addcardtohand();
        Addcardtohand();

    }
    private void Awake()
    {
        Addcardtohand();
    }

    // Update is called once per frame
    public void Addcardtohand()
    {
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        handCards.Add(newCard);

        UpdateHandVisuals();
    }
    private void Update()
    {
        // Update the hand visuals every frame if needed
        UpdateHandVisuals();
    }

    public void UpdateHandVisuals()
    {
        int cardCount = handCards.Count;
        for (int i = 0; i < cardCount; i++)
        {
            float angle = (i - (cardCount - 1 ) / 2f) * fanspread;
            handCards[i].transform.localRotation = Quaternion.Euler(0, 0, angle);
            float horizontalOffset = i * cardspacing;
            handCards[i].transform.localPosition = new Vector3(horizontalOffset, 0f, 0f);
        }
    }
}

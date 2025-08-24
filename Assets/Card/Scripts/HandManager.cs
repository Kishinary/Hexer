using CardScripts;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HandManager : MonoBehaviour
{

    public GameObject cardPrefab; // assign the card prefab in the inspector
    public Transform handTransform; // Hand position in the scene
    public float fanspread = -4f;
   
    public float cardspacing = 70f; // Adjust this value to change the spacing between cards
    public List<GameObject> handCards = new List<GameObject>();


    public void Addcardtohand(Card carddata)
    {
            GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
            handCards.Add(newCard);


            newCard.GetComponent<CardDisplay>().carddata = carddata;
        UpdateHandVisuals();
    }

    public void RemoveCardFromHand(Card card)
    {
        GameObject cardToRemove = handCards.Find(c => c.GetComponent<CardDisplay>().carddata == card);
        if (cardToRemove != null)
        {
            handCards.Remove(cardToRemove);
            UpdateHandVisuals();
        }
    }
    private void Update()
    {
        UpdateHandVisuals();
        handCards.RemoveAll(item => item == null);
    }

    public void UpdateHandVisuals()
    {
        int cardCount = handCards.Count;

        if (cardCount == 1)
        {
            handCards[0].transform.localPosition = new Vector3(0f, 0f, 0f);
        }


        for (int i = 0; i < cardCount; i++)
        {
            float horizontalOffset = cardspacing * (i - (cardCount - 1) / 2f);
            handCards[i].transform.localPosition = new Vector3(horizontalOffset, 0f, 0f);

        }
    }
}

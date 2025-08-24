using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using CardScripts;

public class DeckManager : MonoBehaviour
{
    public List<Card> AllCards = new List<Card>();

    private int currentIndex = 0;


    public int startingHandSize = 5;

    public int MaxHandSize = 10;

    public int currentHandSize;

    private HandManager handManager;


    public void DrawCard(HandManager handManager)
    {
        if (AllCards.Count == 0)
        return;
        Card nextCard = AllCards[currentIndex];
        
        if (currentHandSize < MaxHandSize)
        {
            handManager.Addcardtohand(nextCard);
            currentIndex = (currentIndex + 1) % AllCards.Count;
        }
    }
    private void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Cards");

        AllCards.AddRange(cards); // Load all cards from the Resources folder
        handManager = FindAnyObjectByType<HandManager>();

        for (int i = 0; i < 6; i++)
        {
            DrawCard(handManager);
        }
    }

    public void Update()
    {
        if (handManager != null) 
            {
                currentHandSize = handManager.handCards.Count;
        }
    }
}

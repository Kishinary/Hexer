using CardScripts;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class DrawPileManager : MonoBehaviour
{
    public List<Card> drawPile = new List<Card>();
    private int currentIndex = 0;


    public int startingHandSize = 5;

    public int MaxHandSize = 10;

    public int currentHandSize;

    private HandManager handManager;

    private DiscardManager discardManager;

    public TextMeshProUGUI drawPileCounter;


    public void DrawCard(HandManager handManager)
    {
        if (drawPile.Count == 0)
        {
            RefillDeckFromDiscard();
        }


        if (currentHandSize < MaxHandSize)
        {
            Card nextCard = drawPile[currentIndex];
            handManager.Addcardtohand(nextCard);
            drawPile.RemoveAt(currentIndex);
            UpdateDrawPileCount();
           if (drawPile.Count > 0)
            {
                currentIndex = currentIndex % drawPile.Count;
            }
        }
}

    private void RefillDeckFromDiscard()
    {
        if (discardManager == null)
        {
            discardManager = FindAnyObjectByType<DiscardManager>();
        }
        if (discardManager != null && discardManager.discardCards.Count > 0)
        {
            drawPile = discardManager.GetAllDiscardCards();
            discardManager.discardCards.Clear();
            Utility.Shuffle(drawPile);
            currentIndex = 0;
            UpdateDrawPileCount();
        }
    }
    private void Start()
    {
        handManager = FindAnyObjectByType<HandManager>();
    }

    public void Update()
    {
        if (handManager != null)
        {
            currentHandSize = handManager.handCards.Count;
        }
    }
    public void MakeDrawPile(List<Card> cardsToAdd)
    {
        drawPile.AddRange(cardsToAdd);
        Utility.Shuffle(drawPile);
        UpdateDrawPileCount();
}
    private void UpdateDrawPileCount()
    {
        drawPileCounter.text = drawPile.Count.ToString();
    }


    public void BattleSetup(int numberOfCardsToDraw, int setMaxHandSize)
    {
        MaxHandSize = setMaxHandSize;
        for (int i = 0; i < numberOfCardsToDraw; i++)
        {
            DrawCard(handManager);
        }
    }
}

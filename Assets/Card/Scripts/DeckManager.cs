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


    private DrawPileManager drawPileManager;

    private bool startBattleRun = true;
    private void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Cards");

        AllCards.AddRange(cards); // Load all cards from the Resources folder
        handManager = FindAnyObjectByType<HandManager>();


    }

    private void Awake()
    {
        if (drawPileManager == null)
        {
            drawPileManager = FindAnyObjectByType<DrawPileManager>();
        }
        if (handManager == null)
        {
            handManager = FindAnyObjectByType<HandManager>();
        }
    }
    private void Update()
    {
        if(startBattleRun)
        {
            BattleSetUp();
        }
    }

    public void BattleSetUp()
    {
        handManager.BattleSetup(MaxHandSize);
        drawPileManager.MakeDrawPile(AllCards);
        drawPileManager.BattleSetup(startingHandSize, MaxHandSize);
        startBattleRun = false;
    }
}



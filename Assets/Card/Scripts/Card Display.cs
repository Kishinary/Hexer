using UnityEngine;
using System.Collections;
using System.Collections.Generic;   
using UnityEngine.UI;
using TMPro;
using CardScripts;
public class CardDisplay : MonoBehaviour
{

    public Card carddata;
    public Image cardImage;
    public TMP_Text cardName;
    public TMP_Text cardDescription;
    public TMP_Text cardenergy;

    public Image[] typeimages;


    public Image[] cardBackgrounds;


    void Start()
    {
        UpdateCardDisplay();
        UpdateCardBackground();
        cardImage.SetNativeSize();
    }

    public void UpdateCardDisplay()
    {

        cardImage.sprite = carddata.cardImage;
        cardName.text = carddata.cardName;
        cardDescription.text = carddata.cardDescription;
        cardenergy.text = carddata.CardEnergyCost.ToString();

        if (carddata.cardtype.Contains(Card.CardType.Melee))
        {
            typeimages[0].gameObject.SetActive(true);
        }
        if (carddata.cardtype.Contains(Card.CardType.Ranged))
        {
            typeimages[1].gameObject.SetActive(true);
        }
        if (carddata.cardtype.Contains(Card.CardType.Magic))
        {
            typeimages[2].gameObject.SetActive(true);
        }
        if (carddata.cardtype.Contains(Card.CardType.Summon))
        {
            typeimages[3].gameObject.SetActive(true);
        }
        if (carddata.cardtype.Contains(Card.CardType.Support))
        {
            typeimages[4].gameObject.SetActive(true);
        }
       
    }
    public void UpdateCardBackground()
    {
        if (carddata.cardTheme.Contains(Card.CardTheme.StoneAge))
        {
            cardBackgrounds[0].gameObject.SetActive(true);
        }
        if (carddata.cardTheme.Contains(Card.CardTheme.MedievalAge))
        {
            cardBackgrounds[1].gameObject.SetActive(true);
        }
        if (carddata.cardTheme.Contains(Card.CardTheme.ModernAge))
        {
            cardBackgrounds[2].gameObject.SetActive(true);
        }
        if (carddata.cardTheme.Contains(Card.CardTheme.FutureAge))
        {
            cardBackgrounds[3].gameObject.SetActive(true);
        }
        if (carddata.cardTheme.Contains(Card.CardTheme.DaSea))
        {
            cardBackgrounds[4].gameObject.SetActive(true);
        }
    } 
}

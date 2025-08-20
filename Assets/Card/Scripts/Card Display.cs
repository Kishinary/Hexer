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
     


    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {

        cardImage.sprite = carddata.cardImage;
        cardName.text = carddata.cardName;
        cardDescription.text = carddata.cardDescription;
        cardenergy.text = carddata.CardEnergyCost.ToString();


        for (int i = 0; i < typeimages.Length; i++)
        {
            if (i < carddata.cardtype.Count)
            {
                typeimages[i].gameObject.SetActive(true);
            }
        }
    }
}

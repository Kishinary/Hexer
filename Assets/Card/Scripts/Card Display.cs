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


    public Image[] typeimages;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {

        cardImage.sprite = carddata.cardImage;
        cardName.text = carddata.cardName;
        cardDescription.text = carddata.cardDescription;
        
    }
}

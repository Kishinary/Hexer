using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
namespace CardScripts
{
    [CreateAssetMenu (fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject
    {
        public Sprite cardImage;
        public string cardName;
        public string cardDescription;
        public List <CardType> cardtype;


        public List<DamageType> damagetype;
        public int damage;
        public int minimumDamage;
        public int maximumDamage;

        public int CardEnergyCost;


        private int range;




        public int CardID;

        public enum CardType
        {
            Melee,
            Ranged,
            Magic,
            Summon,
            Support
        }
        public enum DamageType
        {
            Melee,
            Ranged,
            Magic,
            Summon,
            Support
        }

        public void Range() 
            {
            if (cardtype[0] == CardType.Melee) 
                {
                    range = 1;
            }
            if (cardtype[0] == CardType.Ranged) 
                {
                    range = 3;
            }
        } 

        public void UseCard()
        {
            switch(CardID)
            {
                case 0:
                    Debug.Log("Card Used: " + cardName);
                    break;
                case 1:
                    Debug.Log("Card Used: " + cardName);
                    break;
                case 2:
                    Debug.Log("Card Used: " + cardName);
                    break;
                default:
                    Debug.Log("Card Used: " + cardName);
                    break;
            }
        }

    }
   
}


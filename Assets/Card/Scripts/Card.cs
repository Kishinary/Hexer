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


        public int damage;

        public int CardEnergyCost;
        

        private int range;
        public int weight;

        public List<CardTheme> cardTheme;

        public int CardID;



        public GameObject weaponPrefab;
        public enum CardType
        {
            Melee,
            Ranged,
            Magic,
            Summon,
            Support
        }
        public enum CardTheme
        {
            StoneAge,
            MedievalAge,
            ModernAge,
            FutureAge,
            DaSea
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
            GameObject player = GameObject.FindWithTag("Player");
            if (cardtype.Contains(CardType.Melee) || cardtype.Contains(CardType.Ranged))
            {
                Instantiate(weaponPrefab, new Vector3(0.09f, -0.05f, 0f), Quaternion.identity, player.GetComponent<PlayerWeapon>().weaponPos.transform);
            }
            switch (CardID)
            {
                case 0: //Swordy
                    break;
                case 1: //Bowy
                    Debug.Log("Card Used: " + cardName);
                    break;
                case 2: //Staffy
                    Debug.Log("Card Used: " + cardName);
                    break;
                case 3:
                    Debug.Log("Card Used: " + cardName);
                    break;
            }
        }

    }
   
}


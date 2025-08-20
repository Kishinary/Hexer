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
    }
   
}


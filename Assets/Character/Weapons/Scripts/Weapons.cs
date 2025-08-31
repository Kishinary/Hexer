using CardScripts;
using System.Collections.Generic;
using UnityEngine;
using static CardScripts.Card;
namespace Weapon
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]

    public class Weapons : ScriptableObject
    {
        public Sprite WeaponImage;
        public string WeaponName;
        public string cardDescription;
        public List<CardType> cardtype;


        public int damage;
        private int range;
        public int WeaponID;
    }
}


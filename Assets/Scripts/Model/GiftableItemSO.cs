using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class GiftableItemSO : ItemSO, IItemAction, IDestroyableItem
    {
        private List<GiftableData> giftModifier = new List<GiftableData>();
        public string ActionName => "Gift";

        public AudioClip actionSFX {get; private set;}

        public bool PerformAction(GameObject character)
        {
            //TODO: code how to gift an item to an NPC
            foreach (GiftableData data in giftModifier)
            {
                data.giftModifier.AffectGift(character, data.item);
            }
            return true;
        }
    }

    public interface IDestroyableItem //- allows object to be destroyed
    {
    }

    public interface IItemAction
    {
        public string ActionName {get;}
        public AudioClip actionSFX {get;}
        bool PerformAction(GameObject character);
    }

    public class GiftableData
    {
        public GiftModifierSO giftModifier;
        public GiftableItemSO item;
    }
}

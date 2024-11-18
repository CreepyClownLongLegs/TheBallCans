using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    public class GiftableItemSO : ItemSO, IItemAction //, IDestroyableItem
    {
        public string ActionName => "Gift";

        public AudioClip actionSFX {get; private set;}

        public bool PerformAction(GameObject character)
        {
            //TODO: code how to gift an item to an NPC
            throw new System.NotImplementedException();
        }
    }

    /*public interface IDestroyableItem - allows object to be destroyed
    {
    }*/

    public interface IItemAction
    {
        public string ActionName {get;}
        public AudioClip actionSFX {get;}
        bool PerformAction(GameObject character);
    }
}

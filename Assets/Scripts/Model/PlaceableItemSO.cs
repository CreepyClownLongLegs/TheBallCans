using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class PlaceableItemSO : ItemSO, IItemAction, IDestroyableItem
    {
        [field: SerializeField]
        private List<PlaceableData> modifiersData = new List<PlaceableData>();
        public string ActionName => "Place Item";

        [field: SerializeField]
        public AudioClip actionSFX {get; private set;}

        public bool PerformAction(GameObject character)
        {
            //TODO: code how to place object in YourRoom Scene
            foreach (PlaceableData data in modifiersData)
            {
                data.roomModifier.AffectRoom(character, data.item, data.coords);
            }
            return true;
        }
    }

    [Serializable]

    public class PlaceableData
    {
        public RoomModifierSO roomModifier;
        public PlaceableItemSO item;
        public Vector3 coords;
    }   
}

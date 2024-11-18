using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

public abstract class GiftModifierSO : ScriptableObject
{
    public abstract void AffectGift(GameObject character, GiftableItemSO item);
}

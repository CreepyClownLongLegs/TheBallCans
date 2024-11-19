using System.Collections;
using System.Collections.Generic;
using Inventory;
using Inventory.Model;
using UnityEngine;

[CreateAssetMenu]
public class GiveGiftModifierSO : GiftModifierSO
{
    [SerializeField] string AffectedPlayerTag;
    private bool playerCloseEnough = false;
    public override void AffectGift(GameObject character, GiftableItemSO item)
    {
        

    }




}

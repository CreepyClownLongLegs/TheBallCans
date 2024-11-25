using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

[CreateAssetMenu]
public class GiveGiftModifierSO : GiftModifierSO
{
    public override void AffectGift(GameObject character, GiftableItemSO item)
    {
        //give gift to specific NPC when in range
        if (true)
        {
            
        }
        else
        {
            NotificationManager.Instance.showNotification("That person is too far away.", NotificationPanelColor.INFO);
        }
    }
}

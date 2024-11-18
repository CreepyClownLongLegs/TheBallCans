using System;
using System.Collections;
using System.Collections.Generic;
using Inventory.Model;
using UnityEngine;

public abstract class RoomModifierSO : ScriptableObject
{
    public abstract void AffectRoom(GameObject character, PlaceableItemSO item, Vector3 coords);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New shield Item Data", menuName = "Scriptable Object/Item Data - shield", order = 6)]
public class ItemData_Shield : ItemData_EquipItem
{
    [Header("무기 데이터")]
    public float defencePower = 15;

    public override EquipPartType EquipPart => EquipPartType.Shield;

    //public override void EquipItem(GameObject target)
    //{
    //} 

    //public override void ToggleEquipItem(GameObject target)
    //{
    //}

    //public override void UnEquipItem(GameObject target)
    //{
    //}
}

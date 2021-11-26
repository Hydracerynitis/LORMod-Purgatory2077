// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[战斗开始] 本书页有20%几率瞄准友方单位
    public class DiceCardSelfAbility_MFST2 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[战斗开始] 本书页有20%几率瞄准友方单位";
        public override void OnStartBattle()
        {
            if (RandomUtil.valueForProb > 0.2)
                return;
            BattleUnitModel victim = RandomUtil.SelectOne<BattleUnitModel>(BattleObjectManager.instance.GetAliveList(owner.faction));
            card.target = victim;
            card.targetSlotOrder = RandomUtil.Range(0, victim.cardSlotDetail.cardAry.Count - 1);
        }
    }
}

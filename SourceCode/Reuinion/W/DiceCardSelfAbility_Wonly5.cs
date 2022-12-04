// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;
using LOR_DiceSystem;

namespace Ark
{
    //本书页费用根据全场单位腐蚀层数提升 [装备时] 获得本书页当前费用数的[强壮]
    public class DiceCardSelfAbility_Wonly5 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "本书页费用根据全场单位腐蚀层数提升 [装备时] 获得本书页当前费用数的[强壮]";
        public override int GetCostLast(BattleUnitModel unit, BattleDiceCardModel self, int oldCost)
        {
            int decay = unit.bufListDetail.GetKewordBufStack(KeywordBuf.Decay);
            if (decay < 5)
                return 0;
            if (decay >= 10)
                return 2;
            return 1;
        }
        public override void OnUseInstance(BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            int cost = self.GetCost();
            unit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Strength, cost, owner);
        }
    }
}

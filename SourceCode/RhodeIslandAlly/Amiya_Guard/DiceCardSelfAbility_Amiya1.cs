// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[装备时]恢复4点光芒
    public class DiceCardSelfAbility_Amiya1 : DiceCardSelfAbilityBase 
    {
        public static string Desc = "[装备时]恢复4点光芒";

        public override string[] Keywords => new string[1] { "Energy_Keyword" };

        public override void OnUseInstance( BattleUnitModel unit, BattleDiceCardModel self, BattleUnitModel targetUnit)
        {
            int playPoint = unit.cardSlotDetail.PlayPoint;
            unit.cardSlotDetail.RecoverPlayPointByCard(4);
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[锈锤之战][战斗开始]所有友方下一幕中获得1层[伤害提升]
    public class DiceCardSelfAbility_15A7P1037 : DiceCardSelfAbilityBase 
    {
        public static string Desc = "[锈锤之战][战斗开始]所有友方下一幕中获得1层[伤害提升]";
        public override void OnStartBattle()
        {
            foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList(owner.faction))
                unit.bufListDetail.AddKeywordBufByCard(KeywordBuf.DmgUp, 1,owner);

        }
    }
}

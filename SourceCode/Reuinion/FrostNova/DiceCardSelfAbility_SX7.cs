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
    //[战斗开始] 使所有友方单位获得1层束缚
    public class DiceCardSelfAbility_SX7 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始] 使所有友方单位获得1层束缚";
        public override void OnStartBattle()
        {
            foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList(owner.faction))
                unit.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 1, owner);
        }
    }
}

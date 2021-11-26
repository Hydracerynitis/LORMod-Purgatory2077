// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[命中时] 使所有单位获取1层束缚
    public class DiceCardAbility_SXAOE :DiceCardAbilityBase 
    {
        public static string Desc = "[命中时] 使所有单位获取1层束缚";
        public override void OnSucceedAreaAttack(BattleUnitModel target)
        {
            foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList())
                unit.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 1, owner);
        }
    }
}

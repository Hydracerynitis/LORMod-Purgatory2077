// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[拼点胜利] 这一幕对所有敌方单位施加一层[束缚]
    public class DiceCardAbility_GZ1 :DiceCardAbilityBase 
    {
        public static string Desc = "[拼点胜利] 这一幕对所有敌方单位施加一层[束缚]";
        public override void OnWinParrying()
        {
            foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_opponent(owner.faction))
                unit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Binding, 1);
        }
    }
}

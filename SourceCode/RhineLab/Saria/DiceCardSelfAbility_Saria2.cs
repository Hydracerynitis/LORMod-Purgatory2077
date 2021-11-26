// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Saria2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;
using System.Collections.Generic;

namespace Ark
{
    //[使用时]消耗[充能]层数最高的友方单位4层[充能]并使其在这一幕及下一幕获得3层[守护]
    public class DiceCardSelfAbility_Saria2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]消耗[充能]层数最高的友方单位4层[充能]并使其在这一幕及下一幕获得3层[守护]";
        public override string[] Keywords => new string[2]{ "WarpCharge", "Protection_keyword" };
        public override void OnUseCard()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(owner.faction);
            if (aliveList.Count <= 0)
                return;
            aliveList.Sort((x, y) => y.bufListDetail.GetKewordBufStack(KeywordBuf.WarpCharge) - x.bufListDetail.GetKewordBufStack(KeywordBuf.WarpCharge));
            if (aliveList[0].bufListDetail.GetActivatedBuf(KeywordBuf.WarpCharge) is BattleUnitBuf_warpCharge activatedBuf && activatedBuf.stack >= 4)
            {
                activatedBuf.UseStack(4, true);
                aliveList[0].bufListDetail.AddKeywordBufByCard(KeywordBuf.Protection, 3, owner);
                aliveList[0].bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 3, owner);
            }
        }
    }
}

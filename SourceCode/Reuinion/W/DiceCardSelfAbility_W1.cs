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
    //[使用时] 丢弃手中左右的书页并且使本书页所有骰子威力+[所有敌方单位]的[腐蚀]总层数
    public class DiceCardSelfAbility_W1 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时] 丢弃手中左右的书页并且使本书页所有骰子威力+[所有敌方单位]的[腐蚀]总层数";
        public override void OnUseCard()
        {
            int CorrosionStack = 0;
            BattleObjectManager.instance.GetAliveList_opponent(owner.faction).ForEach(x => CorrosionStack += x.bufListDetail.GetKewordBufStack(KeywordBuf.Decay));
            owner.allyCardDetail.DiscardInHand(owner.allyCardDetail.GetHand().Count);
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { power = CorrosionStack });
        }
    }
}

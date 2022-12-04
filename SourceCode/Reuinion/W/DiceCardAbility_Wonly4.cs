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
    //目标每有1层[腐蚀]本骰子威力/混乱伤害+2 [命中时]清空目标[腐蚀]层数
    public class DiceCardAbility_Wonly4 :DiceCardAbilityBase 
    {
        public static string Desc = "目标每有1层[腐蚀]本骰子威力/混乱伤害+2 [命中时]清空目标[腐蚀]层数";
        public override void BeforeRollDice()
        {
            int decay = card.target.bufListDetail.GetKewordBufStack(KeywordBuf.Decay);
            behavior.ApplyDiceStatBonus(new DiceStatBonus() { power = 2 * decay, breakDmg = 2 * decay });
        }
        public override void OnSucceedAttack()
        {
            card.target.bufListDetail.RemoveBufAll(KeywordBuf.Decay);
        }
    }
}

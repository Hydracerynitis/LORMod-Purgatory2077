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
    //[使用时]目标[腐蚀]高于5层则使其这一幕与下一幕所有骰子基础值-3
    public class DiceCardSelfAbility_Wonly2 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时]目标[腐蚀]高于5层则使其这一幕与下一幕所有骰子基础值-3";
        public override void OnUseCard()
        {
            if (card.target.bufListDetail.GetKewordBufStack(KeywordBuf.Decay) <= 5)
                return;
            card.target.bufListDetail.AddBuf(new Reduce());
        }
        public class Reduce: BattleUnitBuf
        {
            private bool firstTurn = false;
            public override void OnRoundEnd()
            {
                if (firstTurn)
                    Destroy();
                else
                    firstTurn = true;
            }
            public override void BeforeRollDice(BattleDiceBehavior behavior)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus() { min = -3, max = -3 });
            }
        }
    }
}

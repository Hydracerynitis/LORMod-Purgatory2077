﻿// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //使目标骰子威力-自身[束缚]层数
    public class DiceCardAbility_SX6 :DiceCardAbilityBase 
    {
        public static string Desc = "使目标骰子威力-自身[束缚]层数";
        public override void BeforeRollDice() => behavior.TargetDice?.ApplyDiceStatBonus(new DiceStatBonus() { power=-owner.bufListDetail.GetKewordBufStack(KeywordBuf.Binding)});
    }
}

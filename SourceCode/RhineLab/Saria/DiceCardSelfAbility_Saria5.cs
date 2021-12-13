// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Saria3
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;
using System.Collections.Generic;

namespace Ark
{
    //[拼点胜利]本场战斗累积消耗的[充能]超过30层时摧毁目标书页所有骰子
    public class DiceCardSelfAbility_Saria5 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[拼点胜利]本场战斗累积消耗的[充能]超过30层时摧毁目标书页所有骰子";
        public override string[] Keywords => new string[] { "WarpCharge" };
        public override void OnWinParryingAtk()
        {
            if (Harmony_Patch.WarpUseHistory.TryGetValue(owner.UnitData, out int value) && value > 30)
                card.target.currentDiceAction.DestroyDice(DiceMatch.AllDice);
        }
    }
}

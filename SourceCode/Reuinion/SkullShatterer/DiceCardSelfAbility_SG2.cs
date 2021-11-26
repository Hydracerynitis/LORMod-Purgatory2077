// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[拼点开始] 本书页所有骰子最小值+5
    public class DiceCardSelfAbility_SG2 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[拼点开始] 本书页所有骰子最小值+5";
        public override void OnStartParrying() => card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { min = 5 });

    }
}

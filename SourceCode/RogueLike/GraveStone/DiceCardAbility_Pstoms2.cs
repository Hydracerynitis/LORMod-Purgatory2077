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
    //对持有[墓标]的目标骰子最终值翻倍
    public class DiceCardAbility_Pstoms2 : DiceCardAbilityBase 
    {
        public static string Desc = "对持有[墓标]的目标骰子最终值翻倍";
        public override void BeforeRollDice()
        {
            if (BattleUnitBuf_tomsEX.GetBuf(card.target, out BattleUnitBuf_tomsEX Buf))
                behavior.abilityList.Add(new DiceCardAbility_powerDouble());
        }
    }
}

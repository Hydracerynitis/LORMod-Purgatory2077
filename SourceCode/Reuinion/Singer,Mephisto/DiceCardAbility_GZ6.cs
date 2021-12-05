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
    //以本骰子进行拼点时不会受到任何伤害
    public class DiceCardAbility_GZ6 : DiceCardAbilityBase
    {
        public static string Desc = "以本骰子进行拼点时不会受到任何伤害";
        public override void BeforeRollDice()
        {
            if (behavior.TargetDice == null)
                return;
            behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus() { dmgRate = -9999, breakRate = -9999 });
        }
    }
}

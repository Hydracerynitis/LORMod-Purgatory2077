// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //自身混乱抗性高于50%本骰子威力+1
    public class DiceCardAbility_MFST1 :DiceCardAbilityBase 
    {
        public static string Desc = "自身混乱抗性高于50%本骰子威力+1";
        public override void BeforeRollDice()
        {
            if (owner.breakDetail.breakGauge>owner.breakDetail.GetDefaultBreakGauge()/2)
                behavior.ApplyDiceStatBonus(new DiceStatBonus() { power = 1 });
        }
    }
}

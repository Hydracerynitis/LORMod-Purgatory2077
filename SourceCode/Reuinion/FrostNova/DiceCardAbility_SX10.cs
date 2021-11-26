// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[命中时] 当自身[束缚]层数不低于5则使目标陷入[混乱]
    public class DiceCardAbility_SX10 :DiceCardAbilityBase 
    {
        public static string Desc = "[命中时] 当自身[束缚]层数不低于5则使目标陷入[混乱]";
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (owner.bufListDetail.GetKewordBufStack(KeywordBuf.Binding) < 5)
                return;
            target.breakDetail.breakGauge = 0;
            target.breakDetail.breakLife = 0;
            target.breakDetail.DestroyBreakPoint();
        }
    }
}

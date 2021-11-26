// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时] 使所有敌方单位受到[束缚]层数x2的混乱伤害
    public class DiceCardSelfAbility_MFST5: DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时] 使所有敌方单位受到[束缚]层数x2的混乱伤害";
        public override void OnUseCard()
        {
            foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_opponent(owner.faction))
                unit.TakeBreakDamage(unit.bufListDetail.GetKewordBufStack(KeywordBuf.Binding) * 2, DamageType.Card_Ability, owner);
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;
using System;
namespace Ark
{
    //影刃战术     每有一名友方单位存活则使自身获得1层“忍耐”(至多2层)
    public class PassiveAbility_100121 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            int ally = BattleObjectManager.instance.GetAliveList(owner.faction).FindAll(x => x != owner).Count;
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, Math.Min(ally, 2));
        }
    }
}

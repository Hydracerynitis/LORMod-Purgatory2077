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
    //当有友方单位死亡时才能使用
    public class DiceCardSelfAbility_SX9 : DiceCardSelfAbilityBase
    {
        public static string Desc = "当有友方单位死亡时才能使用";
        public override bool OnChooseCard(BattleUnitModel owner) => BattleObjectManager.instance.GetList(owner.faction).Exists(x => x.IsDead());
    }
}

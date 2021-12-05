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
    //[强壮]不低于6层才可使用书页
    public class DiceCardSelfAbility_FSD6 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[强壮]不低于6层才可使用书页";
        public override bool OnChooseCard(BattleUnitModel owner) => owner.bufListDetail.GetKewordBufStack(KeywordBuf.Strength) >= 6;
    }
}

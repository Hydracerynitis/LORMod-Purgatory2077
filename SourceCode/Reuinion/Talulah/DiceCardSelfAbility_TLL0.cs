// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时] 抽取所有名字为[余烬]的书页
    public class DiceCardSelfAbility_TLL0 : DiceCardSelfAbilityBase
    {
        private static List<int> AshCombatPageList = new List<int> (){ 1,2,3,4};  
        public static string Desc = "[使用时] 抽取所有名字为[余烬]的书页";
        public override void OnUseCard() => AshCombatPageList.ForEach(x => owner.allyCardDetail.DrawCardsAllSpecific(new LorId("Purgatory2077", x)));
    }
}

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
    //[使用时]丢弃手中所有书页并获得丢弃书页数的[充能]并在下一幕开始抽取丢弃手中书页数的书页
    public class DiceCardSelfAbility_Ptilopsis_EX : DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时]丢弃手中所有书页并获得丢弃书页数的[充能]\n并在下一幕开始抽取丢弃手中书页数的书页";
        public override void OnUseCard()
        {
            int cards = owner.allyCardDetail.GetHand().Count;
            owner.allyCardDetail.DiscardInHand(cards);
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.WarpCharge, cards, owner);
            owner.bufListDetail.AddBuf(new DrawCard(cards));
        }
    }
}

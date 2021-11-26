// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时] 这一幕中对目标施加[烧伤]层数+1
    public class DiceCardSelfAbility_TLL8 :DiceCardSelfAbilityBase 
    {
        public static string Desc = "[使用时] 这一幕中对目标施加[烧伤]层数+1";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddBuf(new MoreBurn(card.target));
        }
        public class MoreBurn: BattleUnitBuf
        {
            private BattleUnitModel victim;
            public MoreBurn(BattleUnitModel unit) => victim = unit;
            public override int OnGiveKeywordBufByCard(BattleUnitBuf cardBuf, int stack, BattleUnitModel target) => cardBuf.bufType == KeywordBuf.Burn && target == victim ? 1 : 0;
            public override void OnRoundEnd() => Destroy();
        }
    }
}

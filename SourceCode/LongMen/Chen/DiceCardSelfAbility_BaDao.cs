// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_BaDao
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;

namespace Ark
{
    //[拼点开始]如果目标所用书页为单骰书页则使本书页所有骰子威力+10并在下一幕中使自身获得6层[虚弱]与2层[迅捷]
    public class DiceCardSelfAbility_BaDao : DiceCardSelfAbilityBase
    {
        public static string Desc = "[拼点开始]如果目标所用书页为单骰书页则使本书页所有骰子威力+10并在下一幕中使自身获得6层[虚弱]与2层[迅捷]";
        public override void OnStartParrying()
        {
            BattleUnitModel target = this.card.target;
            if (target == null || target.currentDiceAction == null || target.currentDiceAction.GetOriginalDiceBehaviorList().FindAll(x => x.Type != BehaviourType.Standby).Count != 1)
                return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ power = 10 });
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Weak, 6, null);
            owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Quickness, 2, null);
        }
    }
}

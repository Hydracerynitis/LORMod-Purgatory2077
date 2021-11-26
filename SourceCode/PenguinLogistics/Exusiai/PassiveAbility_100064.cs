// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100064
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //胡乱行事      自身手牌数不高于4时自身所用远程书页伤害+50%
    public class PassiveAbility_100064 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetSpec().Ranged != CardRange.Far || owner.allyCardDetail.GetHand().Count > 4)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ dmgRate = 50 });
        }
    }
}

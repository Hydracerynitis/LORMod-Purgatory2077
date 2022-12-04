// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System;
using LOR_DiceSystem;

namespace Ark
{
    //曼德拉注目     无法更改战斗书页且无法转移属于曼德拉的被动 每一幕开始手中书页不少于5张 血量高于50%时无视近战书页的伤害(不无视混乱伤害)且被近战书页单方面攻击时摧毁目标书页所有骰子(陷入混乱后此被动移出)
    public class PassiveAbility_100091 : PassiveAbilityBase
    {
        private bool Activate => owner.hp>owner.MaxHp/2;
        private bool AttackByNear=false;
        public override void OnRoundStart()
        {
            AttackByNear = false;
            owner.allyCardDetail.DrawCards(Math.Max(5 - owner.allyCardDetail.GetHand().Count, 0));
        }
        public override void OnStartTargetedOneSide(BattlePlayingCardDataInUnitModel attackerCard)
        {
            if (attackerCard.card.GetSpec().Ranged == CardRange.Near && Activate)
            {
                attackerCard.DestroyDice(DiceMatch.AllDice);
                AttackByNear = true;
            }
            else
                AttackByNear = false;
        }
        public override void OnStartParrying(BattlePlayingCardDataInUnitModel card)
        {
            if (card.target.currentDiceAction.card.GetSpec().Ranged == CardRange.Near && Activate)
                AttackByNear = true;
            else
                AttackByNear = false;
        }
        public override bool IsImmuneDmg()
        {
            return AttackByNear && Activate;
        }
        public override void OnBreakState()
        {
            owner.passiveDetail.DestroyPassive(this);
        }
    }
}

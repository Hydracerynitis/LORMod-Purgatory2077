// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100033
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;

namespace Ark
{
    //双连射   使用远程书页连续命中目标两次时额外追加7点伤害
    public class PassiveAbility_100033 : PassiveAbilityBase
    {
        private BattleUnitModel _target;
        private int _stack;
        public override void OnRollDice(BattleDiceBehavior behavior)
        {
            if (!IsAttackDice(behavior.Detail) || _target == null || _target == behavior.card.target || behavior.card.card.GetSpec().Ranged != CardRange.Far)
                return;
            if (_target.bufListDetail.GetActivatedBufList().Find(x => x is BloodBath_HandDebuf) is BloodBath_HandDebuf bloodBathHandDebuf)
                _target.bufListDetail.RemoveBuf(bloodBathHandDebuf);
            _target = null;
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (_target == behavior.card.target && behavior.card.card.GetSpec().Ranged == CardRange.Far)
            {
                ++_stack;
                if (_target.bufListDetail.GetActivatedBufList().Find(x => x is BloodBath_HandDebuf) is BloodBath_HandDebuf bloodBathHandDebuf)
                    bloodBathHandDebuf.OnHit();
                if (_stack < 2)
                    return;
                Ability();
            }
            else
            {
                _target = behavior.card.target;
                _stack = 1;
                _target.bufListDetail.AddBuf(new BloodBath_HandDebuf());
                if (_target.bufListDetail.GetActivatedBufList().Find(x => x is BloodBath_HandDebuf) is BloodBath_HandDebuf bloodBathHandDebuf)
                    bloodBathHandDebuf.OnHit();
            }
        }
        private void Ability()
        {
            if (_target == null)
                return;
            _target.TakeDamage(7, DamageType.Passive, owner);
            if (_target.bufListDetail.GetActivatedBufList().Find(x => x is BloodBath_HandDebuf) is BloodBath_HandDebuf bloodBathHandDebuf)
                _target.bufListDetail.RemoveBuf(bloodBathHandDebuf);
            _target = null;
            _stack = 0;
        }
        public class BloodBath_HandDebuf : BattleUnitBuf
        {
            public BloodBath_HandDebuf() => stack = 0;
            public void OnHit() => ++stack;
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100027
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;
using System.Collections.Generic;

namespace Ark
{
    //重力控制      使用持有三颗不同类型的“进攻型”骰子的战斗书页命中目标时追加3点混乱伤害
    public class PassiveAbility_100027 : PassiveAbilityBase
    {
        private bool _tri;
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            _tri = false;
            List<BehaviourDetail> behaviourDetailList = new List<BehaviourDetail>();
            foreach (DiceBehaviour originalDiceBehavior in curCard.GetOriginalDiceBehaviorList())
            {
                if (originalDiceBehavior.Type == BehaviourType.Atk && originalDiceBehavior.Detail != BehaviourDetail.None && !behaviourDetailList.Exists(x => x == originalDiceBehavior.Detail))
                    behaviourDetailList.Add(originalDiceBehavior.Detail);
            }
            if (behaviourDetailList.Count < 3)
                return;
            _tri = true;
            owner.battleCardResultLog?.SetPassiveAbility(this);
        }
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (!_tri)
                return;
            behavior.card.target.TakeBreakDamage(3, DamageType.Passive);
        }
    }
}

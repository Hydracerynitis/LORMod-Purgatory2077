// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100083
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using UnityEngine;

namespace Ark
{
    //医者仁心      可以瞄准友方单位并使造成的伤害全部转换为50%的体力/混乱抗性恢复
    public class PassiveAbility_100083 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (behavior.card.target.faction != owner.faction)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.card.target.RecoverHP(behavior.DiceResultValue / 2);
            behavior.card.target.breakDetail.RecoverBreak(behavior.DiceResultValue / 2);
        }
        public override bool TeamKill() => true;
        public override BattleUnitModel ChangeAttackTarget(BattleDiceCardModel card, int currentSlot)
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList().FindAll(x => x!=owner);
            return aliveList.Count > 0 ? aliveList[Random.Range(0, aliveList.Count)] : base.ChangeAttackTarget(card, currentSlot);
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.card.target.faction != owner.faction)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){dmgRate = -9999, breakRate = -9999 });
        }
  }
}

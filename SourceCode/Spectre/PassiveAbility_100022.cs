// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100022
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //精神错乱/精神锁定     命中目标时减少自身1点混乱抗性/这一幕开始时若混乱抗性低于5则直接恢复所有混乱抗性
    public class PassiveAbility_100022 : PassiveAbilityBase
    {
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (!IsNearOrFar(behavior.card.card))
                return;
            owner.TakeBreakDamage(1, DamageType.Passive);
        }
        public override void OnRoundEnd()
        {
            if (owner.breakDetail.breakGauge > 5 || owner.breakDetail.breakLife == 0)
                return;
            owner.RecoverBreakLife(owner.MaxBreakLife);
            owner.breakDetail.ResetGauge();
            owner.breakDetail.nextTurnBreak = false;
            owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
        }
    }
}

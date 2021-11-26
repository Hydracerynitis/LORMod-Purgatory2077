// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100043
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //双重爆炸      以范围杀伤书页命中目标时追加4点混乱伤害
    public class PassiveAbility_100043 : PassiveAbilityBase
    {
        public override void OnSucceedAreaAttack(BattleDiceBehavior behavior, BattleUnitModel target)
        {
            if (!IsAttackDice(behavior.Detail) || behavior.card.target == null)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.card.target.TakeBreakDamage(4, DamageType.Passive);
        }
    }
}

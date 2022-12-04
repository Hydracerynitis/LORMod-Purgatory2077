// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_HDK6
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //源石病变      每当以进攻型骰子命中目标时的伤害永久+1点(至多28点) 若使用进攻型骰子时拼点失败/打平则清除所有伤害提升并重新计数
    public class PassiveAbility_HDK6 : PassiveAbilityBase
    {
        private int dmgup;
        public override void AfterGiveDamage(int damage)
        {
            ++dmgup;
            if (dmgup >=28)
                dmgup = 28;
        }
        public override void OnDrawParrying(BattleDiceBehavior behavior)
        {
            if (IsAttackDice(behavior.Detail))
                dmgup = 0;
        }
        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            if (IsAttackDice(behavior.Detail))
                dmgup = 0;
        }
        public override void BeforeGiveDamage(BattleDiceBehavior behavior) => behavior.ApplyDiceStatBonus(new DiceStatBonus(){ dmg = dmgup });
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100059
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //铝热出鞘      50%的概率使突刺混乱伤害+6
    public class PassiveAbility_100059 : PassiveAbilityBase
    {
        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            if (behavior.Detail != BehaviourDetail.Penetrate || RandomUtil.valueForProb >= 0.5)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ breakDmg = 6 });
        }
    }
}

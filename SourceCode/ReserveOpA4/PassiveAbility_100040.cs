// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100040
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //铠甲突破      击中目标时25%追加4点混乱伤害
    public class PassiveAbility_100040 : PassiveAbilityBase
    {
        private float _prob = 0.25f;
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if ((double) RandomUtil.valueForProb >= (double) _prob)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.card?.target?.TakeBreakDamage(4, DamageType.Passive, owner);
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_HDK2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //物理防护护盾    受到的混乱伤害-2~6且可以使用专属书页[锈锤之战](不可转移)
    public class PassiveAbility_HDK2 : PassiveAbilityBase
    {
        public override int GetBreakDamageReductionAll(int dmg, DamageType dmgType, BattleUnitModel attacker) => RandomUtil.Range(2, 6);
    }
}

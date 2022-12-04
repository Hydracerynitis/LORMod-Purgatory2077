// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100037
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //活力再生      当自身受到致死伤害时使其恢复50体力随后移除此被动
    public class PassiveAbility_100037 : PassiveAbilityBase
    {
        public override bool BeforeTakeDamage(BattleUnitModel attacker, int dmg)
        {
            bool flag = false;
            if ((int) ((double) this.owner.hp - (double) dmg) < 1)
            {
                owner.battleCardResultLog?.SetPassiveAbility(this);
                owner.RecoverHP(50);
                flag = true;
                owner.passiveDetail.DestroyPassive(this);
            }
            return flag;
        }
    }
}

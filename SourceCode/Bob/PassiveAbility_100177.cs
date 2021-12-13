// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //自爆    受到致命伤害时对攻击者返还其造成伤害x2的伤害
    public class PassiveAbility_100177 : PassiveAbilityBase
    {
        private int Dmg = 0;
        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            if (attacker != null)
                Dmg = dmg;
            else
                Dmg = 0;
        }
        public override void OnDie()
        {
            if (Dmg > 0)
                owner.lastAttacker.TakeDamage(2 * Dmg);
        }
    }
}

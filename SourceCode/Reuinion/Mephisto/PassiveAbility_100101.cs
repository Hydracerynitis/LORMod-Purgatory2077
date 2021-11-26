// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100101
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //源石粉末      每一幕开始自身减少5体力并使所有友方单位恢复4体力
    public class PassiveAbility_100101 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            owner.TakeDamage(5, DamageType.Passive);
            foreach(BattleUnitModel unit in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                if (unit != owner)
                    unit.RecoverHP(4);
            }
        }
    }
}

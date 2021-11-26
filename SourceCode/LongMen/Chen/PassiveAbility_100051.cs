// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100051
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    //心有余悸      每有一名友方单位死亡则使自身所有骰子威力+1(至多+2)
    public class PassiveAbility_100051 : PassiveAbilityBase
    {
        private int _death=0;
        public override void OnDieOtherUnit(BattleUnitModel unit)
        {
            if (unit.faction != this.owner.faction)
                return;
            ++_death;
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior) => behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = Math.Min(_death, 2) });
  }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100028
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    //天体仪   每使用一次[星象连转]自身所有骰子威力永久+1(至多+5)
    public class PassiveAbility_100028 : PassiveAbilityBase
    {
        private int _num;
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = Math.Min(_num, 5) });
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard.card.GetID() != new LorId("Purgatory2077", 50))
                return;
            ++_num;
        }
    }
}

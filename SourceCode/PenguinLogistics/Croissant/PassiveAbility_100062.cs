// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100062
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //奇迹护体      所用书页第一颗若为防御型骰子则使其威力+2
    public class PassiveAbility_100062 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard) => curCard.ApplyDiceAbility(DiceMatch.NextDice,  new DiceCardAbility_passive(this));
        public class DiceCardAbility_passive : DiceCardAbilityBase
        {
            private PassiveAbility_100062 _passive;
            public DiceCardAbility_passive(PassiveAbility_100062 p) => _passive = p;
            public override void BeforeRollDice()
            {
                if (IsDefenseDice(behavior.Detail))
                {
                    behavior.ApplyDiceStatBonus(new DiceStatBonus() { power = 2 });
                    owner.battleCardResultLog?.SetPassiveAbility(_passive);
                }
            }
        }
    }
}

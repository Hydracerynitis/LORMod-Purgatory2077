// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_exusiai3
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //本书页骰子将重复投掷8次
    public class DiceCardSelfAbility_exusiai3 : DiceCardSelfAbilityBase
    {
        public static string Desc = "本书页骰子将重复投掷8次";
        public override void OnUseCard()
        {
            base.OnUseCard();
            foreach(BattleDiceBehavior dice in card.GetDiceBehaviorList())
            {
                dice.abilityList.Add(new Repeat8() { behavior=dice});
            }
        }
        public class Repeat8: DiceCardAbilityBase
        {
            private int _repeatCount;
            public override void AfterAction()
            {
                if (owner.IsBreakLifeZero() || _repeatCount >= 7)
                    return;
                ++_repeatCount;
                ActivateBonusAttackDice();
            }
        }
    }
}

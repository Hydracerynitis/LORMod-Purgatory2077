// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100066
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //演出开始      第一幕中使自身防御型骰子威力+4
    public class PassiveAbility_100066 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (Singleton<StageController>.Instance.RoundTurn != 1 || !IsDefenseDice(behavior.Detail))
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = 4 });
        }
    }
}

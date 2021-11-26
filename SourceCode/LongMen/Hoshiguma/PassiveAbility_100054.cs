// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100054
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //特种作战策略    “防御型”骰子威力+2
    public class PassiveAbility_100054 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (!IsDefenseDice(behavior.Detail))
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = 2 });
        }
    }
}

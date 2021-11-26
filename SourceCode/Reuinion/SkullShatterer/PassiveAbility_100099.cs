// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100099
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //病魔缠身/最后反击     舞台开启时摧毁自身一颗速度骰子且速度永远为2/与防御骰拼点时使其骰子威力-3
    public class PassiveAbility_100099 : PassiveAbilityBase
    {
        public override void OnAfterRollSpeedDice()
        {
            foreach (Dice dice in owner.speedDiceResult)
                dice.value = 2;
            owner.view.speedDiceSetterUI.SetSpeedDicesAfterRoll(owner.speedDiceResult);
        }
        public override int SpeedDiceBreakedAdder() => 1;
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.TargetDice == null || !IsDefenseDice(behavior.TargetDice.Detail))
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus(){ power = -3 });
        }
    }
}

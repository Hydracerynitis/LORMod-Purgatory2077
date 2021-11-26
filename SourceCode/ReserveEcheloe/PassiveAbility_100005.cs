// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100005
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //反击战术  使用反击骰时使其最小值+2
    public class PassiveAbility_100005 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Type != BehaviourType.Standby)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ min=2 });
        }
    }
}

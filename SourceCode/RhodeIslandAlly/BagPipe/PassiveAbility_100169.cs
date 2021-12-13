// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;
namespace Ark
{
    //维多利亚之锋  突刺骰子威力+1 伤害+25%
    public class PassiveAbility_100169 : PassiveAbilityBase
    {
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Detail != BehaviourDetail.Penetrate)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus() { power = 1, dmgRate = 25 });
        }
    }
}

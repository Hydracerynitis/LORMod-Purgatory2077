// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_croissant1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //手中每持有1张书页本骰子威力便-1
    public class DiceCardAbility_croissant1 : DiceCardAbilityBase
    {
        public static string Desc = "手中每持有1张书页本骰子威力便-1";
        public override void BeforeRollDice()
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ power = -owner.allyCardDetail.GetHand().Count });
        }
    }
}

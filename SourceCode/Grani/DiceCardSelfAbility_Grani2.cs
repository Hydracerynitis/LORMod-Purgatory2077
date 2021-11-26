// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Grani2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]丢弃所有书页 每丢弃1张书页则使本书页所有骰子威力+1
    public class DiceCardSelfAbility_Grani2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]丢弃所有书页 每丢弃1张书页则使本书页所有骰子威力+1";
        public override void OnUseCard()
        {
            int count = owner.allyCardDetail.GetHand().Count;
            owner.allyCardDetail.DiscardACardByAbility(owner.allyCardDetail.GetHand());
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ power = count });
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;
namespace Ark
{
    //萨科塔的左轮弹巢  来自一个未知死者的遗物 当司书尝试装备上其效果时将会获得未知来源的力量 自身所有穿刺骰子威力+1 每当使用第六张书页时则使其中所有骰子威力-6
    public class PassiveAbility_100176 : PassiveAbilityBase
    {
        private int Count = 0;
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            Count++;
            if (Count == 6)
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { power = -6 });
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (behavior.Detail != BehaviourDetail.Penetrate)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus() { power = 1});
        }
    }
}

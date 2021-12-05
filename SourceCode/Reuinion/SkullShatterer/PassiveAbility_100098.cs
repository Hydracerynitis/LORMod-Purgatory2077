// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100098
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using LOR_DiceSystem;

namespace Ark
{
    //战术变换      若以远程书页开始拼点时将本书页骰子威力+1并变为近战书页
    public class PassiveAbility_100098 : PassiveAbilityBase
    {
        public override void OnStartParrying(BattlePlayingCardDataInUnitModel curCard)
        {
            if(curCard.card.GetSpec().Ranged== CardRange.Far)
            {
                DiceCardSpec spec = curCard.card.GetSpec().Copy();
                spec.Ranged = CardRange.Near;
                curCard.card.CopySelf();
                curCard.card.XmlData.Spec = spec;
                curCard.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus() { power = 1 });
            }
        }
        public override void OnEndBattle(BattlePlayingCardDataInUnitModel curCard)
        {
            curCard.card.ResetToOriginalData();
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100085
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System;
using System.Collections.Generic;
namespace Ark
{
    //协同指令      每与一名友方单位的骰子瞄准同一个目标时造成的伤害/混乱伤害+1
    public class PassiveAbility_100085 : PassiveAbilityBase
    {
        Dictionary<BattlePlayingCardDataInUnitModel, int> AttackNumber = new Dictionary<BattlePlayingCardDataInUnitModel, int>();
        private Predicate<BattlePlayingCardDataInUnitModel> CheckUnity(BattlePlayingCardDataInUnitModel self)
        {
            return x => x.owner!= self.owner && x.owner.faction == self.owner.faction && x.target == self.target;
        }

        public override void OnStartBattle()
        {
            AttackNumber.Clear();
            foreach (BattlePlayingCardDataInUnitModel cardDataInUnitModel in owner.cardSlotDetail.cardAry)
            {
                if (cardDataInUnitModel == null)
                    continue;
                if (!AttackNumber.ContainsKey(cardDataInUnitModel))
                    AttackNumber.Add(cardDataInUnitModel, Singleton<StageController>.Instance.GetAllCards().FindAll(CheckUnity(cardDataInUnitModel)).Count);
            }
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (AttackNumber.ContainsKey(curCard))
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { dmg = AttackNumber[curCard], breakDmg = AttackNumber[curCard] });
        }
    }
}

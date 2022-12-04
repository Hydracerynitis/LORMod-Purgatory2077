// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100085
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System;
using System.Collections.Generic;
namespace Ark
{
    //共同进击      与任意一个友方的骰子共同瞄准一个目标时自身骰子威力+1 骰子伤害+1(不可叠加)
    public class PassiveAbility_HDK5: PassiveAbilityBase
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
            if (AttackNumber.ContainsKey(curCard) && AttackNumber[curCard]>0)
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus() { dmg = 1, power=1 });
        }
    }
}

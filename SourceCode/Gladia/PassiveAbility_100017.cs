// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100017
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;

namespace Ark
{
    //深海刺穿者     自身速度大于目标时所用书页所有骰子最大值+1并且使用"歌蕾蒂娅"书页时最小值额外+1
    public class PassiveAbility_100017 : PassiveAbilityBase
    {
        private static List<int> cards = new List<int>() { 34, 35, 36, 37, 38, 39, 40, 41, 42 };
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            BattleUnitModel target = curCard.target;
            int targetSlotOrder = curCard.targetSlotOrder;
            int max = 0;
            int min = 0;
            if (targetSlotOrder > 0 && targetSlotOrder < target.speedDiceResult.Count)
            {
                SpeedDice speedDice = target.speedDiceResult[targetSlotOrder];
                if (curCard.speedDiceResultValue > speedDice.value)
                    max = 1;
            }
            LorId id = curCard.card.GetID();
            if (id.packageId == "Purgatory2077" && cards.Contains(id.id))
                min = 1;
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ max = max,min=min  });
        }
    }
}

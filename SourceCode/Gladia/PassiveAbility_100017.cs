// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100017
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //深海刺穿者     自身速度大于目标时所用书页所有骰子最大值+1
    public class PassiveAbility_100017 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            BattleUnitModel target = curCard.target;
            int targetSlotOrder = curCard.targetSlotOrder;
            if (targetSlotOrder < 0 || targetSlotOrder >= target.speedDiceResult.Count)
                return;
            SpeedDice speedDice = target.speedDiceResult[targetSlotOrder];
            if (curCard.speedDiceResultValue <= speedDice.value)
                return;
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ max = 1  });
        }
    }
}

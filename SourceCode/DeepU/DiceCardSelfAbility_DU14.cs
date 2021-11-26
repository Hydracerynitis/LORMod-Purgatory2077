// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU14
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //自身速度大于目标时使本书页所有骰子威力+3
    public class DiceCardSelfAbility_DU14 : DiceCardSelfAbilityBase
    {
        public static string Desc = "自身速度大于目标时使本书页所有骰子威力+3";
        public override void OnUseCard()
        {
            BattleUnitModel target = card.target;
            int targetSlotOrder = card.targetSlotOrder;
            if (targetSlotOrder < 0 || targetSlotOrder >= target.speedDiceResult.Count)
                return;
            SpeedDice speedDice = target.speedDiceResult[targetSlotOrder];
            if (card.speedDiceResultValue <= speedDice.value)
                return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ power = 3 });
        }
    }
}

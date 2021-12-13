// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU9
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;

namespace Ark
{
    //[使用时] 若自身持有振奋且速度高于目标则使本书页所有骰子威力+2
    public class DiceCardSelfAbility_DU9 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时] 若自身持有振奋且速度高于目标则使本书页所有骰子威力+2";
        public override void OnUseCard()
        {
            BattleUnitModel target = this.card.target;
            int targetSlotOrder = this.card.targetSlotOrder;
            if (targetSlotOrder < 0 || targetSlotOrder >= target.speedDiceResult.Count)
                return;
            SpeedDice speedDice = target.speedDiceResult[targetSlotOrder];
            if (card.speedDiceResultValue <= speedDice.value || this.owner.bufListDetail.GetKewordBufStack(KeywordBuf.BreakProtection) <= 0)
                return;
            card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ power = 2 });
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100021
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //稳定持握  所用书页骰子数量大于2时每多有1颗骰子便使本书页所有骰子最小值+1
    public class PassiveAbility_100021 : PassiveAbilityBase
    {
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            int count = curCard.GetOriginalDiceBehaviorList().Count;
            if (count < 2)
                return;
            owner.battleCardResultLog?.SetPassiveAbility(this);
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus(){ min = count - 2 });
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_HDK6
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //源石病变      每造成一次伤害自身造成的伤害永久+1点(至多20点) 若书页使用时未造成任何伤害则清除所有伤害提升并重新计数(不可转移)
    public class PassiveAbility_HDK6 : PassiveAbilityBase
    {
        private int dmgup;
        private int dmgcount;
        private BattlePlayingCardDataInUnitModel cardModel;
        public override void AfterGiveDamage(int damage)
        {
            ++dmgup;
            if (dmgup >=20)
                dmgup = 20;
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard == null)
                return;
            cardModel = curCard;
            dmgcount = owner.history.damageAtOneRoundByDice;
        }
        public override void OnEndBattle(BattlePlayingCardDataInUnitModel curCard)
        {
            if (curCard == null || cardModel == null || curCard != cardModel || dmgcount != owner.history.damageAtOneRoundByDice)
                return;
            dmgup = 0;
        }
        public override void BeforeGiveDamage(BattleDiceBehavior behavior) => behavior.ApplyDiceStatBonus(new DiceStatBonus(){ dmg = dmgup });
    }
}

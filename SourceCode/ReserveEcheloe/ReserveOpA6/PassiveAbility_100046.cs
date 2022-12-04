// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100046
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //慵懒        每一幕开始使自己与随机一名友方恢复5点体力 每当自身转移核心书页时强化被动: 1 - 每一幕所有友方恢复1点混乱抗性; 2 - 每一幕开始获得1层"守护"; 3 - 招架骰子威力+1; 4 - 每一幕开始获得1层"强壮"
    public class PassiveAbility_100046 : PassiveAbilityBase
    {
        private int Enhance;
        public override void Init(BattleUnitModel self)
        {
            Enhance = self.equipment.book.GetEquipedBookList(true).Count;
            base.Init(self);
        }
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            base.BeforeRollDice(behavior);
            if (Enhance >= 3 && IsDefenseDice(behavior.Detail))
                behavior.ApplyDiceStatBonus(new DiceStatBonus() { power = 1 });
        }
        public override void OnRoundStart()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList_random(owner.faction, 1))
                battleUnitModel.RecoverHP(5);
            owner.RecoverHP(5);
            if (Enhance >= 1)
                BattleObjectManager.instance.GetAliveList(owner.faction).ForEach(x => x.breakDetail.RecoverBreak(1));
            if (Enhance >= 2)
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 1);
            if (Enhance >= 4)
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 1);
        }
    }
}

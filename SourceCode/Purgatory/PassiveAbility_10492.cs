// Decompiled with JetBrains decompiler
// Type: Purgatory.PassiveAbility_10492
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //变幻莫测  记忆混乱，使书页费用为0 每隔一幕时获得1颗速度骰子(至多获得7颗)
    public class PassiveAbility_10492 : PassiveAbilityBase
    {
        private int _patternCount=0;
        private int _speedDiceNumAdder;
        public override int SpeedDiceNumAdder() => _speedDiceNumAdder;
        public override void OnRoundStartAfter()
        {
            owner.allyCardDetail.ExhaustAllCards();
            AddNewCard(1);
            AddNewCard(2);
            AddNewCard(3);
            AddNewCard(3);
            AddNewCard(4);
            AddNewCard(5);
            AddNewCard(6);
            AddNewCard(7);
            AddNewCard(8);
            AddNewCard(9);
            ++_patternCount;
            _patternCount %= 2;
            if (_patternCount == 0)
                ++_speedDiceNumAdder;
            if (_speedDiceNumAdder < 7)
                return;
            _speedDiceNumAdder = 7;
        }
        private void AddNewCard(int id)
        {
            BattleDiceCardModel battleDiceCardModel = this.owner.allyCardDetail.AddNewCard(new LorId("Purgatory2077", id));
            if (battleDiceCardModel == null)
                return;
            battleDiceCardModel.SetCostToZero();
            return;
        }
    }
}

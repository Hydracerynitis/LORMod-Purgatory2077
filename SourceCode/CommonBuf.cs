using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark
{
    public class DrawCard: BattleUnitBuf
    {
        private int count;
        public DrawCard(int Count) => count = Count;
        public override void OnRoundEnd()
        {
            _owner.allyCardDetail.DrawCards(count);
            Destroy();
        }
    }
    public class Stealth : BattleUnitBuf
    {
        public override bool IsTargetable() => false;
        public override void OnRoundEnd() => Destroy();
    }
    public class RecoverEnergy: BattleUnitBuf
    {
        private int count;
        public RecoverEnergy(int Count) => count = Count;
        public override void OnRoundEnd()
        {
            _owner.cardSlotDetail.RecoverPlayPoint(count);
            Destroy();
        }
    }
    public class Critical : BattleUnitBuf
    {
        public BattlePlayingCardDataInUnitModel currentCard;
        public override void ChangeDiceResult(BattleDiceBehavior behavior, ref int diceResult)
        {
            if (currentCard != null && behavior.card == currentCard)
                diceResult = behavior.GetDiceMax();
        }
        public override void OnRoundEnd() => Destroy();
    }
}

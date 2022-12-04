using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ark
{
    class BattleUnitBuf_tomsEX: BattleUnitBuf
    {
        public BattleUnitModel unit;
        private int period;
        public override bool independentBufIcon => true;
        protected override string keywordId => "tomsEX";
        public static void AddBuff(BattleUnitModel unit, int stack, BattleUnitModel GraveStone, bool IsReady)
        {
            if (IsReady)
            {
                if (unit.bufListDetail.GetReadyBufList().Find(x => x is BattleUnitBuf_tomsEX) is BattleUnitBuf_tomsEX tomsEX && tomsEX.unit == GraveStone)
                    tomsEX.stack += stack;
                else
                {
                    tomsEX = new BattleUnitBuf_tomsEX() { stack = stack, unit = GraveStone, period = 2 };
                    unit.bufListDetail.AddReadyBuf(tomsEX);
                }
                tomsEX.stack = Math.Min(1, tomsEX.stack);
            }
            else
            {
                if (unit.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_tomsEX) is BattleUnitBuf_tomsEX tomsEX && tomsEX.unit == GraveStone)
                    tomsEX.stack += stack;
                else
                {
                    tomsEX = new BattleUnitBuf_tomsEX() { stack = stack, unit = GraveStone, period = 2 };
                    unit.bufListDetail.AddBuf(tomsEX);
                }
                tomsEX.stack = Math.Min(1, tomsEX.stack);
            }
        }
        public static bool GetBuf(BattleUnitModel model, out BattleUnitBuf_tomsEX Buf)
        {
            Buf = null;
            BattleUnitBuf_tomsEX tomsEX = model.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_tomsEX) as BattleUnitBuf_tomsEX;
            if (tomsEX == null)
                return false;
            Buf = tomsEX;
            return true;
        }
        public override void OnTakeDamageByAttack(BattleDiceBehavior atkDice, int dmg)
        {
            if (atkDice.card.card.GetID() == new LorId("Purgatory2077", 509))
                period = 2;
        }
        public override void OnRoundEnd()
        {
            period--;
            if (period <= 0)
                Destroy();
        }
    }
}

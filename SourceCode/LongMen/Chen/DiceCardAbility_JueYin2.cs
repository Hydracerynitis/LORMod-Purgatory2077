// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_JueYin2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //消耗所有[虚弱]并将本骰子重复投掷[消耗层数]的次数(至多9次)
    public class DiceCardAbility_JueYin2 : DiceCardAbilityBase
    {
        private int _cnt;
        public static string Desc = "消耗所有[虚弱]并将本骰子重复投掷[消耗层数]的次数(至多9次)";
        public override void OnAfterAreaAtk(List<BattleUnitModel> damagedList, List<BattleUnitModel> defensedList)
        {
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Weak && activatedBuf.stack >= 1)
                {
                    for (; activatedBuf.stack > 0 && _cnt <= 9; ++_cnt)
                    {
                        --activatedBuf.stack;
                        behavior.card.AddDice(behavior);
                    }
                    if (activatedBuf.stack > 0)
                        activatedBuf.stack = 0;
                    activatedBuf.Destroy();
                }
            }
        }
    }
}

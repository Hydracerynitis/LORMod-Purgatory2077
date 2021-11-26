// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_JueYin
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //自身每有1层[虚弱]则消耗1层[虚弱]并重复投掷本骰子(至多8次)
    public class DiceCardAbility_JueYin : DiceCardAbilityBase
    {
        private int _cnt;
        public static string Desc = "自身每有1层[虚弱]则消耗1层[虚弱]并重复投掷本骰子(至多8次)";
        public override void AfterAction()
        {
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Weak && activatedBuf.stack >= 1 && _cnt <= 8)
                {
                    --activatedBuf.stack;
                    ActivateBonusAttackDice();
                    ++_cnt;
                }
            }
        }
    }
}

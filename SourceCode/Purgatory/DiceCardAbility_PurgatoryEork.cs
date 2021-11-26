// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardAbility_PurgatoryEork
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //骰子最大值增加拼点目标的[烧伤]层数
    public class DiceCardAbility_PurgatoryEork : DiceCardAbilityBase
    {
        public static string Desc = "骰子最大值增加拼点目标的[烧伤]层数";
        public virtual void BeforRollDice()
        {
            if (!IsAttackDice(behavior.Detail))
                return;
            BattleUnitModel target = behavior.card.target;
            if (target == null)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ max = target.bufListDetail.GetKewordBufStack(KeywordBuf.Burn) });
        }
    }
}

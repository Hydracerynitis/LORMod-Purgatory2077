// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardAbility_PurgatoryWork
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //骰子最小值增加拼点目标的[烧伤]层数
    public class DiceCardAbility_PurgatoryWork : DiceCardAbilityBase
    {
        public static string Desc = "骰子最小值增加拼点目标的[烧伤]层数";
        public virtual void BeforRollDice()
        {
            if (!IsAttackDice(behavior.Detail))
                return;
            BattleUnitModel target = behavior.card.target;
            int kewordBufAllStack = target.bufListDetail.GetKewordBufStack(KeywordBuf.Burn);
            if (target == null || kewordBufAllStack <= 0)
                return;
            behavior.ApplyDiceStatBonus(new DiceStatBonus(){ min = kewordBufAllStack });
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_PurgatoryOffBurn
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]使所有单位受到持有[烧伤]层数的伤害
    public class DiceCardSelfAbility_PurgatoryOffBurn : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]使所有单位受到持有[烧伤]层数的伤害";
        public override string[] Keywords => new string[1]{ "Burn_Keyword" };
        public override void OnUseCard()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList())
                alive.TakeDamage(alive.bufListDetail.GetKewordBufStack(KeywordBuf.Burn), DamageType.Card_Ability, owner);
        }
    }
}

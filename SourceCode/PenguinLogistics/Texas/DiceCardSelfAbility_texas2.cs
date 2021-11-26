// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_texas2
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]这一幕命中目标时施加1层[烧伤]
    public class DiceCardSelfAbility_texas2 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]这一幕命中目标时施加1层[烧伤]";
        public override string[] Keywords => new string[2]{ "bstart_Keyword", "Burn_Keyword" };
        public override void OnUseCard() => owner.bufListDetail.AddBuf(new Burn1thisRoundBuf());
        public class Burn1thisRoundBuf : BattleUnitBuf
        {
            public override void OnSuccessAttack(BattleDiceBehavior behavior)
            {
                if (behavior.card.target == null)
                    return;
                behavior.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Burn, 1, _owner);
            }
            public override void OnRoundEnd() => this.Destroy();
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Purgatory.DiceCardSelfAbility_PurgatoryNoBurn
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]所有单位这一幕结束时不会减少[烧伤]层数
    public class DiceCardSelfAbility_PurgatoryNoBurn : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]所有单位这一幕结束时不会减少[烧伤]层数";
        public override void OnUseCard()
        {
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveListExceptFaction(owner.faction))
                battleUnitModel.bufListDetail.AddBuf( new Buf());
        }
        public class Buf : BattleUnitBuf
        {
            public override void OnRoundStart()
            {
                int kewordBufAllStack = _owner.bufListDetail.GetKewordBufStack(KeywordBuf.Burn);
                if (kewordBufAllStack > 0)
                    _owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, kewordBufAllStack / 2 * 3);
                Destroy();
            }
        }
    }
}

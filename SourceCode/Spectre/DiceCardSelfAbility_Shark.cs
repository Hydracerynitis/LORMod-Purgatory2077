// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Shark
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]这一幕中获得3层[守护]并在下一幕中[陷入混乱]
    public class DiceCardSelfAbility_Shark : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]这一幕中获得3层[守护]并在下一幕中[陷入混乱]";
        public override void OnUseCard()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 3, this.owner);
            owner.bufListDetail.AddBuf(new SharkBreakBuf());
        }
        public class SharkBreakBuf : BattleUnitBuf
        {
            public override void OnRoundEnd()
            {
                _owner.breakDetail.breakGauge = 0;
                _owner.breakDetail.breakLife = 0;
                _owner.breakDetail.DestroyBreakPoint();
                Destroy();
            }
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU8
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时] 使这一幕所有的[守护][振奋]转移到下一幕
    public class DiceCardSelfAbility_DU8 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时] 使这一幕所有的[守护][振奋]转移到下一幕";
        public override void OnUseCard()
        {
            foreach (BattleUnitBuf activatedBuf in owner.bufListDetail.GetActivatedBufList())
            {
                if (activatedBuf.bufType == KeywordBuf.Protection)
                {
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, activatedBuf.stack, null);
                    activatedBuf.stack = 0;
                    activatedBuf.Destroy();
                }
                if (activatedBuf.bufType == KeywordBuf.BreakProtection)
                {
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.BreakProtection, activatedBuf.stack, null);
                    activatedBuf.stack = 0;
                    activatedBuf.Destroy();
                }
            }
        }
    }
}

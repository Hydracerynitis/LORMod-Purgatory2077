// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_DU1
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]这一幕获得1层[振奋]并恢复1点光芒
    public class DiceCardSelfAbility_DU1 : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]这一幕获得1层[振奋]并恢复1点光芒";
        public override string[] Keywords => new string[1]{ "bstart_Keyword" };
        public override void OnStartBattle()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 1, this.owner);
            owner.cardSlotDetail.RecoverPlayPointByCard(1);
        }
    }
}

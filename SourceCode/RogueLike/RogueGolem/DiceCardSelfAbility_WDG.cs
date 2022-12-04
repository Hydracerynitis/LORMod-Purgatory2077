// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_Ptilopsis4
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[战斗开始]这一幕中获得3层[守护]并恢复1点光芒
    public class DiceCardSelfAbility_WDG : DiceCardSelfAbilityBase
    {
        public static string Desc = "[战斗开始]这一幕中获得3层[守护]并恢复1点光芒";
        public override void OnStartBattle()
        {
            owner.cardSlotDetail.RecoverPlayPoint(1);
            owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 3, owner);
        }
    }
}

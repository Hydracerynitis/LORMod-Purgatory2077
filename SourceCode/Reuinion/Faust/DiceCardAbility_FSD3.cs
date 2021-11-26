// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[命中时] 下一幕对目标施加3层[虚弱]
    public class DiceCardAbility_FSD3 :DiceCardAbilityBase 
    {
        public static string Desc = "[命中时] 下一幕对目标施加3层[虚弱]";
        public override void OnSucceedAttack(BattleUnitModel target) => target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Weak, 3, owner);
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //源石外壳    每一幕开始随机获得1层“强壮”/“忍耐”/“振奋”/“守护”/“易损”
    public class PassiveAbility_100178 : PassiveAbilityBase
    {
        private static List<KeywordBuf> buffs = new List<KeywordBuf>() { KeywordBuf.Strength, KeywordBuf.Endurance, KeywordBuf.Protection, KeywordBuf.BreakProtection, KeywordBuf.Vulnerable };
        public override void OnRoundStart()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(RandomUtil.SelectOne<KeywordBuf>(buffs), 1);
        }
    }
}

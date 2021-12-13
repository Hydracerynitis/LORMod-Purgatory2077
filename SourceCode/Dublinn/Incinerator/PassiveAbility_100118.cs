// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //焚毁     使用书页施加“烧伤”时重复施加1次
    public class PassiveAbility_100118 : PassiveAbilityBase
    {
        public override int OnGiveKeywordBufByCard(BattleUnitBuf buf, int stack, BattleUnitModel target)
        {
            target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Burn, stack, owner);
            return base.OnGiveKeywordBufByCard(buf, stack, target);
        }
    }
}

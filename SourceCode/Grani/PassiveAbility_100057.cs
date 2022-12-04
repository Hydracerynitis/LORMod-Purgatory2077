// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100057
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    //永不后退/稳扎稳打      当场上无友方存活时每一幕使自身获得1层"强壮"，4层"守护"和"束缚"/舞台开启时自身初始光芒上限减少1点
    public class PassiveAbility_100057 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            if (BattleObjectManager.instance.GetAliveList(owner.faction).Exists(x => x != owner))
                return;
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1, owner);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Disarm, 4, owner);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Binding, 4, owner);
        }
        public override int MaxPlayPointAdder() => -1;
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100086
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //战意转换      每一幕切换一次形态 近战形态无法使用远程书页 远程形态无法使用近战书页 近战获得3层强壮与守护 远程获得3层忍耐与迅捷
    public class PassiveAbility_100086 : PassiveAbilityBase
    {
        private bool isNear = RandomUtil.valueForProb<0.5 ? true : false;
        public override void OnRoundStart()
        {
            isNear = !isNear;
            if (isNear)
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_breakFarCard(owner));
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 3);
            }
            else
            {
                owner.bufListDetail.AddBuf(new BattleUnitBuf_breakNearCard(owner));
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 3);
            }
        }
    }
}

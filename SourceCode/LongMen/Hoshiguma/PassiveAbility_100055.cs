// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100055
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //般若鬼面      每一幕开始使一名友方单位获得3层“守护” 陷入混乱时此被动失效
    public class PassiveAbility_100055 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(owner.faction);
            if (aliveList.Count <= 0)
                return;
            RandomUtil.SelectOne<BattleUnitModel>(aliveList).bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 3);
        }
        public override bool OnBreakGageZero()
        {   
            destroyed = true;
            return base.OnBreakGageZero();
        }
    }
}

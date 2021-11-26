// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100058
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //骑警        每一幕开始时随机两名友方单位获得1层“忍耐”与“守护”
    public class PassiveAbility_100058 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            foreach(BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_random(owner.faction, 2))
            {
                unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 1);
                unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 1);
            }
        }
    }
}

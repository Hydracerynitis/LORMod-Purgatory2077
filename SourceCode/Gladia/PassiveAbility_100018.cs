// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100018
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System;

namespace Ark
{
    //注视    若有友方存活则使全体友方获得1层“守护”若没有友方存活则使自身获得3层“振奋”
    public class PassiveAbility_100018 : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            if (!BattleObjectManager.instance.GetAliveList(owner.faction).Exists(x => x != owner))
                this.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.BreakProtection, 3, owner);
            else
            {
                foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
                    alive.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, 1, this.owner);
            }
        }
    }
}

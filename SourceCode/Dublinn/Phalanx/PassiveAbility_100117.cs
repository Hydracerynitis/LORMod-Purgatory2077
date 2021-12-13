// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100089
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;
using LOR_DiceSystem;

namespace Ark
{
    //卫队方阵     每有一名友方单位存活便使随机一名友方单位获得1层“守护”
    public class PassiveAbility_100117 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            List<BattleUnitModel> ally = BattleObjectManager.instance.GetAliveList(owner.faction).FindAll(x => x != owner);
            for(int i=0; i<ally.Count; i++)
            {
                RandomUtil.SelectOne<BattleUnitModel>(ally).bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 1);
            }
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100014
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //专属-不朽战歌   当自身拥有数层“烟气”时使随机一名友方单位获得数层“振奋”
    public class PassiveAbility_100014 : PassiveAbilityBase
    {
        public override void OnRoundStart()
        {
            int kewordBufAllStack = owner.bufListDetail.GetKewordBufStack(KeywordBuf.Smoke);
            if (kewordBufAllStack <= 0)
                return;
            List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(owner.faction).FindAll(x => x != owner);
            RandomUtil.SelectOne<BattleUnitModel>(aliveList).bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.BreakProtection, kewordBufAllStack);
        }
    }
}

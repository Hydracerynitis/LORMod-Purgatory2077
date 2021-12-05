// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100088
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //青色怒火/影霄       自身强壮不低于3层时使友方单位的所有骰子威力-2 /本幕结束拥有5层强壮时下一幕获得0费的交锋书页
    public class PassiveAbility_100088 : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            if (owner.bufListDetail.GetKewordBufStack(KeywordBuf.Strength) < 5)
                return;
            owner.allyCardDetail.AddNewCard(new LorId("Purgatory2077", 159));
        }
        public override void OnRoundStart()
        {
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction).FindAll(x => x!=owner))
                alive.bufListDetail.AddBuf(new BattleUnitBuf_100088(alive));
        }
     }
}

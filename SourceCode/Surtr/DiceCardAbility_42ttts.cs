// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_42ttts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[命中时] 若目标烟气大于4层则使其下一幕失去2点光芒
    public class DiceCardAbility_42ttts : DiceCardAbilityBase
    {
        public static string Desc = "[命中时] 若目标烟气大于4层则使其下一幕失去2点光芒";
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (target == null || target.bufListDetail.GetKewordBufStack(KeywordBuf.Smoke) <= 4)
                return;
            target.cardSlotDetail.LoseWhenStartRound(2);
        }
    }
}

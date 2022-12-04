// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardAbility_42ttts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll
using System.Collections.Generic;

namespace Ark
{
    //[命中时]将目标这一幕与下一幕的[强壮]掠夺并在下一幕中随机给予其他友方单位
    public class DiceCardAbility_GLDY : DiceCardAbilityBase
    {
        public static string Desc = "[命中时]将目标这一幕与下一幕的[强壮]掠夺并在下一幕中随机给予其他友方单位";
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            int stack = 0;
            int ReadyStack = 0;
            List<BattleUnitBuf> bufs = target.bufListDetail.GetActivatedBufList().FindAll(x => x.bufType == KeywordBuf.Strength);
            bufs.ForEach(x => stack += x.stack);
            bufs.ForEach(x => target.bufListDetail.GetActivatedBufList().Remove(x));
            bufs = target.bufListDetail.GetReadyBufList().FindAll(x => x.bufType == KeywordBuf.Strength);
            bufs.ForEach(x => ReadyStack += x.stack);
            bufs.ForEach(x => target.bufListDetail.GetReadyBufList().Remove(x));
            for (; stack > 0; stack--)
            {
                BattleObjectManager.instance.GetAliveList_random(owner.faction, 1).ForEach(x => x.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 1, owner));
            }
            for (; ReadyStack > 0; ReadyStack--)
            {
                BattleObjectManager.instance.GetAliveList_random(owner.faction, 1).ForEach(x => x.bufListDetail.AddKeywordBufNextNextByCard(KeywordBuf.Strength,1,owner));
            }
        }
    }
}

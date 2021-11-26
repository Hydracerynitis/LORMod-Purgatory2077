// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;

namespace Ark
{
    //[使用时] 若转移了核心书页[歌者]则使所有敌方单位获得1层束缚
    public class DiceCardSelfAbility_MFST6 :DiceCardSelfAbilityBase 
    {
        private const int SingerEquipPageId = 1;
        public static string Desc = "[使用时] 若转移了核心书页[歌者]则使所有敌方单位获得1层束缚";
        public override void OnUseCard()
        {
            List<BookModel> EquipedBook = owner.equipment.book.GetEquipedBookList(true);
            foreach (BookModel model in EquipedBook)
            {
                if (model.BookId == new LorId("Purgatory2077", SingerEquipPageId))
                {
                    foreach (BattleUnitModel unit in BattleObjectManager.instance.GetAliveList_opponent(owner.faction))
                        unit.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 1, owner);
                    return;
                }
            }
        }
    }
}

// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_42ts
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;
using HarmonyLib;
using LOR_DiceSystem;

namespace Ark
{
    //[使用时] 若已转移[不死的黑蛇]则在下一幕使自身获得自身[烧伤]层数的守护
    public class DiceCardSelfAbility_TLL4 : DiceCardSelfAbilityBase
    {
        private const int DeathLessBlackSnakeEquipPageId = 1;
        public static string Desc = "[使用时] 若已转移[不死的黑蛇]则在下一幕使自身获得自身[烧伤]层数的守护";
        public override void OnUseCard()
        {
            List<BookModel> EquipedBook = owner.equipment.book.GetEquipedBookList(true);
            foreach (BookModel model in EquipedBook)
            {
                if (model.BookId == new LorId("Purgatory2077", DeathLessBlackSnakeEquipPageId))
                {
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Protection, owner.bufListDetail.GetKewordBufStack(KeywordBuf.Burn));
                    return;
                }                
            }       
        }
    }
}

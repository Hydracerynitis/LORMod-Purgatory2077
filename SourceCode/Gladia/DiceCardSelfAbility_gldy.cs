// Decompiled with JetBrains decompiler
// Type: Ark.DiceCardSelfAbility_gldy
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //[使用时]若核心书页为[歌蕾蒂娅]则抽取3张书页
    public class DiceCardSelfAbility_gldy : DiceCardSelfAbilityBase
    {
        public static string Desc = "[使用时]若核心书页为[歌蕾蒂娅]则抽取3张书页";
        public override void OnUseCard()
        {
            if (owner.Book.GetBookClassInfoId() == new LorId("Purgatory2077", 9))
                owner.allyCardDetail.DrawCards(3);
            else if (owner.Book.GetBookClassInfoId() == new LorId("Purgatory2077", 10000008))
                owner.allyCardDetail.DrawCards(3);
        }
    }
}

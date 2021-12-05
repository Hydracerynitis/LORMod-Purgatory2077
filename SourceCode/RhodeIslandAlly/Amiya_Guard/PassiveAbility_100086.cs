// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100086
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;

namespace Ark
{
    //战意转换      每一幕切换一次形态 近战形态无法使用远程书页 远程形态无法使用近战书页 近战获得3层强壮与守护 远程获得3层忍耐与迅捷
    public class PassiveAbility_100086 : PassiveAbilityBase
    {
        private BattleAllyCardDetail Far;
        private BattleAllyCardDetail Near;
        private bool isNear;
        public override void OnWaveStart()
        {
            Near = new BattleAllyCardDetail(owner);
            Far = new BattleAllyCardDetail(owner);
            List<DiceCardXmlInfo> deck = new List<DiceCardXmlInfo>();
            foreach (LorId cardId in Singleton<DeckXmlList>.Instance.GetData(new LorId("Purgatory2077", 107)).cardIdList)
                deck.Add(ItemXmlDataList.instance.GetCardItem(cardId));
            Far.Init(deck);
            deck.Clear();
            foreach (LorId cardId in Singleton<DeckXmlList>.Instance.GetData(new LorId("Purgatory2077", 108)).cardIdList)
                deck.Add(ItemXmlDataList.instance.GetCardItem(cardId));
            Near.Init(deck);
            Far.DrawCards(owner.Book.GetStartDraw());
            Near.DrawCards(owner.Book.GetStartDraw());
            isNear = RandomUtil.valueForProb < 0.5 ? true : false;
        }
        public override void OnRoundStart()
        {
            isNear = !isNear;
            if (isNear)
            {
                owner.view.ChangeSkin("Amiya2");
                owner.view.StartEgoSkinChangeEffect("Character");
                owner.allyCardDetail = Near;
                owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 3);
            }
            else
            {
                owner.view.ChangeSkin("Amiya");
                owner.view.StartEgoSkinChangeEffect("Character");
                owner.allyCardDetail = Far;
                owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 3);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Quickness, 3);
            }
        }
    }
}

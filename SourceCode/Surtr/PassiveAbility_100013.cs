// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100013
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System.Collections.Generic;

namespace Ark
{
    //魔剑恢复  所使用的书页具有“烟气”效果时则抽取1张书页(每一幕至多触发1次)
    public class PassiveAbility_100013 : PassiveAbilityBase
    {
        private bool _tri;
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            if (!CheckCondition(curCard) || !_tri)
                return;
            owner.allyCardDetail.DrawCards(1);
            _tri = false;
        }
        private bool CheckCondition(BattlePlayingCardDataInUnitModel card)
        {
            if (card == null)
                return false;
            DiceCardXmlInfo xmlData = card.card.XmlData;
            if (xmlData == null)
                return false;
            if (xmlData.Keywords.Contains("Smoke_Keyword"))
                return true;
            List<string> abilityKeywords = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords(xmlData);
            for (int index = 0; index < abilityKeywords.Count; ++index)
            {
                if (abilityKeywords[index] == "Smoke_Keyword")
                    return true;
            }
            foreach (DiceBehaviour behaviour in card.card.GetBehaviourList())
            {
                List<string> keywordsByScript = Singleton<BattleCardAbilityDescXmlList>.Instance.GetAbilityKeywords_byScript(behaviour.Script);
                for (int index = 0; index < keywordsByScript.Count; ++index)
                {
                    if (keywordsByScript[index] == "Smoke_Keyword")
                        return true;
                }
            }
            return false;
        }
        public override void OnRoundStart() => _tri = true;
    }
}

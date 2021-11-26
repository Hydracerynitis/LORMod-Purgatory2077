// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100003
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    //医疗护理  使上一幕受到最多伤害的友方单位获得5层“振奋”并恢复5体力
    public class PassiveAbility_100003 : PassiveAbilityBase
    {
        public override void OnRoundEnd()
        {
            int num = -1;
            List<BattleUnitModel> list = new List<BattleUnitModel>();
            foreach (BattleUnitModel alive in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                if (!alive.IsExtinction())
                {
                    int damageAtOneRound = alive.history.takeDamageAtOneRound;
                    if (damageAtOneRound > num)
                    {
                        list.Clear();
                        list.Add(alive);
                        num = damageAtOneRound;
                    }
                    else if (damageAtOneRound == num)
                        list.Add(alive);
                }
            }
            if (list.Count <= 0)
                return;
            BattleUnitModel HealUnit = RandomUtil.SelectOne<BattleUnitModel>(list);
            HealUnit.bufListDetail.AddKeywordBufByEtc(KeywordBuf.BreakProtection, 5, owner);
            HealUnit.RecoverHP(5);
        }
    }
}

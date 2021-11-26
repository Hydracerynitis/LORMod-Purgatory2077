// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100080
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using LOR_DiceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ark
{
    //炉心溶解      命中耐性目标时造成一般伤害 命中抵抗目标事造成耐性伤害 (不影响混乱抗性 不可转移)  (敌方aoe摇摆锁敌)
    public class PassiveAbility_100080 : PassiveAbilityBase
    {
        private BattleUnitModel _Target;
        private const string Note = "下面三个数字依次是中，上，下的id，请根据你的需要自行填入";
        private int ID_M = 141;
        private int ID_U = 142;
        private int ID_D = 143;
        private const string Note1 = "了解了，伙计，已经完成了目标等级，今天罗德岛的维修工作也照常进行";
        public override void BeforeGiveDamage(BattleDiceBehavior behavior)
        {
            if (behavior == null)
                return;
            BehaviourDetail detail = behavior.Detail;
            _Target = behavior.card?.target;
            if (_Target.GetResistHP(detail) == AtkResist.Resist)
                _Target.Book.SetResistHP(detail, AtkResist.Endure);
            else if (_Target.GetResistHP(detail) == AtkResist.Endure)
                _Target.Book.SetResistHP(detail, AtkResist.Normal);
        }
        public override void AfterGiveDamage(int damage) => _Target.Book.SetOriginalResists();
        public override BattleUnitModel ChangeAttackTarget(BattleDiceCardModel card, int idx)
        {
            LorId id = card.GetID();
             List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(Faction.Player);
            if (aliveList != null && aliveList.Count == 0)
                return null;
            BattleUnitModel battleUnitModel1 = aliveList[UnityEngine.Random.Range(0, aliveList.Count)];
            if (id == new LorId("Purgatory2077", ID_M))
            {
                BattleUnitModel battleUnitModel2 = aliveList.Find(x => Mathf.Abs(x.formationCellPos.x) == 12);
                if (battleUnitModel2 != null)
                    battleUnitModel1 = battleUnitModel2;
            }
            else if (id == new LorId("Purgatory2077", ID_U))
            {
                List<BattleUnitModel> battleUnitModelList = aliveList.FindAll(x => x.formationCellPos.y == 12);
                if (battleUnitModelList.Count > 0)
                    battleUnitModel1 = RandomUtil.SelectOne<BattleUnitModel>(battleUnitModelList);
            }
            else if (id == new LorId("Purgatory2077", ID_D))
            {
                List<BattleUnitModel> battleUnitModelList = aliveList.FindAll(x => x.formationCellPos.y == -12);
                if (battleUnitModelList.Count > 0)
                    battleUnitModel1 = RandomUtil.SelectOne<BattleUnitModel>(battleUnitModelList);
            }
             return battleUnitModel1;
        }
    }
}

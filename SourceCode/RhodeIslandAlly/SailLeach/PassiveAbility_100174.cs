// Decompiled with JetBrains decompiler
// Type: Ark.PassiveAbility_100069
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

namespace Ark
{
    //军事传统  第一幕中使所有友方单位光芒上限+1并恢复1点光芒 随后光芒上限-1
    public class PassiveAbility_100174 : PassiveAbilityBase
    {
        public override int MaxPlayPointAdder()
        {
            return Singleton<StageController>.Instance.RoundTurn==1? 0 : -1;
        }
        public override void OnWaveStart()
        {
            foreach(BattleUnitModel unit in BattleObjectManager.instance.GetAliveList(owner.faction))
            {
                unit.bufListDetail.AddBuf(new Inspire());
                unit.cardSlotDetail.RecoverPlayPoint(1);
            }
        }
        public class Inspire: BattleUnitBuf
        {
            public override int MaxPlayPointAdder()
            {
                return 1;
            }
            public override void OnRoundEnd()
            {
                Destroy();
            }
        }
    }
}

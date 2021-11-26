// Decompiled with JetBrains decompiler
// Type: Purgatory2077.BehaviourAction_tombstonedawnAction
// Assembly: Purgatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5C0C2E20-DF17-4E33-88D7-BA075DE8EB20
// Assembly location: D:\SteamLibrary\steamapps\common\Library Of Ruina\LibraryOfRuina_Data\Mods\Purgatory2077\Assemblies\Purgatory.dll

using System.Collections.Generic;

namespace Ark
{
    public class BehaviourAction_tombstonedawnAction : BehaviourActionBase
    {
        public override List<RencounterManager.MovingAction> GetMovingAction(ref RencounterManager.ActionAfterBehaviour self,ref RencounterManager.ActionAfterBehaviour opponent)
        {
            List<RencounterManager.MovingAction> movingActionList = new List<RencounterManager.MovingAction>();
            if (self.result == Result.Win && self.data.actionType == ActionType.Atk && !(opponent.behaviourResultData != null && opponent.behaviourResultData.IsFarAtk()))
            {
                RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S1, CharMoveState.MoveForward, 30f, false, 0.5f);
                movingAction.customEffectRes = "FX_PC_RolRang_XSlash_Main_NoUnAtk";
                movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
                movingActionList.Add(movingAction);
                opponent.infoList.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, updateDir: false, delay: 0.5f));
            }
            else
                movingActionList = base.GetMovingAction(ref self, ref opponent);
            return movingActionList;
        }
    }
}

﻿using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        private MonoBehaviour currentAction = default;

        public void StartAction(MonoBehaviour action)
        {
            if(currentAction == action) { return; }
            if (currentAction != null)
            {
                print("Cancelling" + currentAction);
                currentAction = action;
            }
        }
    }
}
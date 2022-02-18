using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    public class UpdateCommand
    {
        /// <summary>
        /// Id of previous action.
        /// </summary>
        public string PrevActionId { get; set; }
        /// <summary>
        /// Previous action type for a document.
        /// </summary>
        public string PrevActionType { get; set; }
        /// <summary>
        /// Id of new action.
        /// </summary>
        public string ActionId { get; set; }
        /// <summary>
        /// New action type for a document.
        /// </summary>
        public string ActionType { get; set; }
        /// <summary>
        /// Previous status.
        /// </summary>
        public string PrevStatus { get; set; }
        /// <summary>
        /// New status.
        /// </summary>
        public string Status { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UpdateCommand command &&
                   PrevActionId == command.PrevActionId &&
                   PrevActionType == command.PrevActionType &&
                   ActionId == command.ActionId &&
                   ActionType == command.ActionType &&
                   PrevStatus == command.PrevStatus &&
                   Status == command.Status;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PrevActionId, PrevActionType, ActionId, ActionType, PrevStatus, Status);
        }
    }
}

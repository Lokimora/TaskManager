using System.Collections.Generic;

namespace TaskManager.DB.Repository.Bonus.PolicyData
{
    public interface IPolicyRepository
    {

        /// <summary>
        /// Get old policies that have last stage update more then 30 days
        /// and that have stage 5
        /// </summary>
        /// <returns></returns>
        IEnumerable<Model.POCO.Policy> GetOldPoliciesToUpdate();

        void UpdatePolicyStage(string podoc, int oldStageId, int newStageId, string stageComment, string userId);
    }
}

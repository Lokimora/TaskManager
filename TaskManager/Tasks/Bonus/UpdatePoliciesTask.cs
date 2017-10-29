using TaskManager.DB.Repository.Bonus;
using TaskManager.DB.Repository.Bonus.PolicyData;
using TaskRunner;

namespace TaskManager.Tasks.Bonus
{
    public class UpdatePoliciesTask : ITask
    {
        private readonly string userUpdateId = "CIS_SMSAdmin";
        private readonly int fromStageId = 5;
        private readonly int toStageId = 9;
        private readonly string stageComment = "Update policy due to 30 days pass since last policy update";

        private readonly IPolicyRepository _policyRepository;

        public UpdatePoliciesTask(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        /// <summary>
        /// move policies from 5 stage to 9 (or maybe 8 idk) with last stage update more than 30 days
        /// </summary>
        /// <param name="option"></param>
        public void Run(object option)
        {

            var policiesToUpdate = _policyRepository.GetOldPoliciesToUpdate();

            foreach (var v in policiesToUpdate)
            {
                _policyRepository.UpdatePolicyStage(v.ActualRewardPolicyCode, fromStageId, toStageId, stageComment,
                    userUpdateId);
            }
        }
    }
}

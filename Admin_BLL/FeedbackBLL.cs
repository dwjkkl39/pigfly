using Admin_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin_DAL;

namespace Admin_BLL
{
    public class FeedbackBLL
    {
        public List<opinionModel> OpinionsList()
        {
            FeedbackDAL feedback = new FeedbackDAL();
            return feedback.OpinionsList();
        }
        //已回复
        public List<opinionModel> Havetoreply()
        {
            FeedbackDAL feedback = new FeedbackDAL();
            return feedback.Havetoreply();
        }
        //未回复
        public List<opinionModel> Didnotreturn()
        {
            FeedbackDAL feedback = new FeedbackDAL();
            return feedback.Didnotreturn();
        }
        //投诉—未投诉
        public List<opinionModel> Complaints(int opBrowsed, int opType)
        {
            FeedbackDAL feedback = new FeedbackDAL();
            return feedback.Complaints(opBrowsed,opType);
        }
        //查询
        public List<opinionModel> Thequery(string opContent)
        {
            FeedbackDAL feedback = new FeedbackDAL();
            return feedback.Thequery(opContent);
        }
        //删除，软删除
        public int DeleteFeedback(int opId, int mid)
        {
            FeedbackDAL feedback = new FeedbackDAL();
            return feedback.DeleteFeedback(opId, mid);
        }
    }
}

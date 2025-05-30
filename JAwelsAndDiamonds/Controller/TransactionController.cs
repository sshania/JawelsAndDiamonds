using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Controller
{
	public class TransactionController
	{
        TransactionRepository tr = new TransactionRepository();
        public List<TransactionHeader> GetUserTransactions(int userId)
        {
            return tr.GetUserTransactions(userId);
        }

        public void ConfirmPackage(int transactionId)
        {
            tr.updateStatus(transactionId, "Done");
        }

        public void RejectPackage(int transactionId)
        {
            tr.updateStatus(transactionId, "Rejected");
        }
    }
}
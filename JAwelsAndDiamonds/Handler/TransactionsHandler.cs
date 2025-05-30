using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Handler
{
	public class TransactionsHandler
	{
        TransactionRepository repo = new TransactionRepository();
        public  List<TransactionDetail> GetTransactionDetails(int transactionId)
        {
            
            return repo.GetTransactionDetails(transactionId);
        }

        public  List<TransactionHeader> GetData()
        {
            return repo.GetFinishedTransaction();
        }
    }
}
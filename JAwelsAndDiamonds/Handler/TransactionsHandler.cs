using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Handler
{
	public class TransactionsHandler
	{
        public static List<TransactionDetail> GetTransactionDetails(int transactionId)
        {
            TransactionRepository repo = new TransactionRepository();
            return repo.GetTransactionDetails(transactionId);
        }
    }
}
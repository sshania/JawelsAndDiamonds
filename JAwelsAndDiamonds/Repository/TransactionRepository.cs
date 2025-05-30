using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repository
{
    public class TransactionRepository
    {
        DatabaseEntities1 db = DatabaseSingleton.getInstance();
        public List<TransactionHeader> getUnfinishedData()
        {
            var unfinishedTransactions = (from x in db.TransactionHeaders
                                          where (x.TransactionStatus == "Payment Pending"
                                                    || x.TransactionStatus == "Shipment Pending"
                                                    || x.TransactionStatus == "Arrived")
                                          select x).ToList();


            return unfinishedTransactions;
        }
        public int InsertTransactionHeader(TransactionHeader header)
        {
            using (DatabaseEntities1 db = new DatabaseEntities1())
            {
                db.TransactionHeaders.Add(header);
                db.SaveChanges();
                return header.TransactionID;
            }
        }
        public void InsertTransactionDetail(TransactionDetail detail)
        {
            using (DatabaseEntities1 db = new DatabaseEntities1())
            {
                db.TransactionDetails.Add(detail);
                db.SaveChanges();
            }
        }

 
        public List<TransactionDetail> GetTransactionDetails(int transactionId)
        {
            return db.TransactionDetails
                     .Where(d => d.TransactionID == transactionId)
                     .ToList();
        }

        public void updateStatus(int id, string newStatus)
        {
            TransactionHeader oldTransaction = db.TransactionHeaders.Find(id);
            if (oldTransaction != null)
            {
                oldTransaction.TransactionStatus = newStatus;
                db.SaveChanges();
            }


        }

        public List<TransactionHeader> GetFinishedTransaction()
        {
            var finishedTransactions = (from x in db.TransactionHeaders where x.TransactionStatus == "Done" select x).ToList();

            return finishedTransactions;
        }

        public List<TransactionHeader> GetUserTransactions(int userId)
        {
            return db.TransactionHeaders
             .Where(t => t.UserID == userId)
             .ToList();
        }

    }
}
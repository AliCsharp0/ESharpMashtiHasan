using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FramWork.DTOS
{
    public class OperationResult //in Natige har Amaliati hast ke ma ba DataBase Bargharar mikhonim
    {
        public bool Success { get; private set; }

        public string Massage { get; private set; }

        public int? RecordID { get; private set; }

        public string Operation { get; private set; }

        public DateTime OperationDate{ get; private set; }

        public OperationResult(string Operation)//in baraie Amaliaty Hast ke RecordID Nadaran
        {
            this.OperationDate = DateTime.Now;
            this.Success = false;
            this.Operation = Operation;
        }
        public OperationResult(string Operation , int RecordID)//in baraie Amaliaty Hast ke RecordID (Darad)
        {
            this.OperationDate = DateTime.Now;
            this.Success = false;
            this.Operation = Operation;      
            this.RecordID = RecordID;
        }

        public OperationResult ToFail(string Message)//baraie zamani ke Amaliat fail mishe
        {
            this.Success = false;
            this.Massage = Message;
            return this;
        }

        public OperationResult ToSuccess(string Message)//baraie zamani ke Amaliat Success mishe
        {
            this.Success = true;
            this.Massage = Message;
            return this;
        }

        public OperationResult ToSuccess(string Message , int RecordID)
        {
            this.Success = true;
            this.Massage = Message;
            this.RecordID = RecordID;
            return this;
        }
    }
}

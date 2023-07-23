using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App1_withMVC.Models
{
    public class QualificationModel
    {
        public int Qid { get; set; }
        public string Qname { get; set; }
        public string SecurityQue { get; set; }
    }
}

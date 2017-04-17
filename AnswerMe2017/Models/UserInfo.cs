using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnswerMe2017.Models
{
    public class UserInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "缺少姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "缺少学号")]
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "缺少手机号")]
        public string Phone { get; set; }

        public decimal Grade { get; set; }

        public int Time { get; set; }
    }
}
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
        [RegularExpression("[\u4E00-\u9FA5]{2,5}(?:·[\u4E00-\u9FA5]{2,5})*", ErrorMessage ="姓名格式不正确")]
        public string Name { get; set; }

        [Required(ErrorMessage = "缺少学号")]
        [RegularExpression("(41|21)[0-9]*",ErrorMessage ="学号格式不正确")]
        public string StudentNumber { get; set; }

        [Required(ErrorMessage = "缺少联系电话")]
        [RegularExpression("[0-9]*", ErrorMessage = "联系电话格式不正确")]
        public string Phone { get; set; }

        public decimal Grade { get; set; }

        public int Time { get; set; }
    }
}
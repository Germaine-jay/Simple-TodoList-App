using System.Collections.Generic;

namespace TodoList.BLL.Models
{
    public class UserWithTaskVM
    {
        public int? Id { get; set; }
        public string Fullname { get; set; }
        public IEnumerable<TaskVM> Tasks { get; set; }

    }
}

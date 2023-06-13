namespace TodoList.BLL.Models
{
    public class TaskVM
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string DueDate { get; set; }
        public string Status { get; set; }
    }
}
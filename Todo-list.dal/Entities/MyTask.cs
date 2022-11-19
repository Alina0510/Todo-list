namespace Todo_list.dal.Entities
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public bool Completed { get; set; }
        public bool Archived { get; set; }
    }
}
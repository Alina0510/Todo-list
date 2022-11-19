using System.Threading.Tasks;
using Todo_list.dal.Entities;

namespace Todo_list.dal
{
    public class HomeHelper
    {

        private TaskDBContext _dbcontext;
        
        public HomeHelper(TaskDBContext context)
        {
            _dbcontext = context;
        }
        public List<MyTask> GetTasks()
        {
            return _dbcontext.Tasks.ToList();
        }
        public void AddTask(MyTask task)
        {
            _dbcontext.Tasks.Add(task);
            _dbcontext.SaveChanges();
        }
        public void Update(bool completed, int id)
        {
            _dbcontext.Tasks.First(i => i.Id == id).Completed = completed;
            _dbcontext.SaveChanges();
        }
        public void Archive(int id)
        {
            _dbcontext.Tasks.First(i => i.Id == id).Archived = true;
            _dbcontext.SaveChanges();
        }
    }
}

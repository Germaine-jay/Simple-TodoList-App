﻿using System.Threading.Tasks;
using TodoList.BLL.Models;
using TodoList.DAL.Entities;

namespace TodoList.BLL.Interfaces
{
    public interface ITodoListService
    {
        Task<(bool successful, string msg)> AddOrUpdateAsync(AddOrUpdateTaskVM model);
        Task<(bool successful, string msg)> DeleteTaskAsync(int userId, int taskId);
        Task<(bool successful, string msg)> ToggleTaskStatus(int userId, int taskId);
        Task<AddOrUpdateTaskVM> GetTask(int userId, int taskId);

    }
}

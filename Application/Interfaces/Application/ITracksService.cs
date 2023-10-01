using Application.DTOS;
using Application.Responses;

namespace Application.Interfaces.Application
{
    public interface ITracksService
    {
        Task<BaseResponse<TaskBaseDto>> CreateTaskProject(TaskDto taskDTO);
        Task<BaseResponse<IEnumerable<TaskBaseDto>>> GetTasks(); 
        Task<BaseResponse<TaskBaseDto>> GetTaskById(int id);
        Task<BaseResponse<TaskBaseDto>> DeleteTask(int id);
        Task<BaseResponse<TaskBaseDto>> UpdateTask(TaskBaseDto taskDTO);
    }
}
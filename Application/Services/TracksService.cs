
namespace Application.Services;
public class TracksService : ITracksService
{
    private readonly ILogger<TracksService> _logger;
    private readonly IAsyncRepository<TaskProject> _tasksRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TracksService(ILogger<TracksService> logger, IAsyncRepository<TaskProject> tasksRepo, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _logger = logger;
        _tasksRepo = tasksRepo;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<TaskBaseDto>> CreateTaskProject(TaskDto taskDTO)
    {
        try
        {
            var mappedTask = _mapper.Map<TaskProject>(taskDTO);
            var checkName = CreatePrevalidationChecks(mappedTask);
            if (checkName.Item1 == false)
            {
                return new BaseResponse<TaskBaseDto>(checkName.Item2, ResponseCodes.DUPLICATE_RESOURCE);
            }
            var createdTaskProject = _tasksRepo.Add(mappedTask);
            await _unitOfWork.CommitChangesAsync();
            var result = _mapper.Map<TaskBaseDto>(createdTaskProject.Result);
            return new BaseResponse<TaskBaseDto>("Task  Created Successfully",result, ResponseCodes.CREATED);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while TaskProject.");
            return new BaseResponse<TaskBaseDto>("An error occurred while TaskProject", ex.Message);
        }
    }
    public async Task<BaseResponse<IEnumerable<TaskBaseDto>>> GetTasks()
    {
        try
        {
            var tasks = await _tasksRepo.GetAll();
            foreach (var task in tasks)
            {
                task.EndDate = task.StartDate.AddHours(task.ElapsedTime);
                task.DueDate = task.StartDate.AddHours(task.AllottedTime);
            }
            var result = _mapper.Map <IEnumerable<TaskBaseDto>>(tasks);
            return new BaseResponse<IEnumerable<TaskBaseDto>>("Retrieved all task successfully", result, ResponseCodes.SUCCESS);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while retrieving list of Task.");
            return new BaseResponse<IEnumerable<TaskBaseDto>>($"An error occurred while retrieving list of Task. {ex.Message})");
        }
    }
    public async Task<BaseResponse<TaskBaseDto>> GetTaskById(int id)
    {
        try
        {
            var task = await _tasksRepo.GetById(id);

            if (task == null)
            {
                return new BaseResponse<TaskBaseDto>("Task not found", ResponseCodes.NOT_FOUND);
            }
            if (!task.TaskStatus) 
            {
                task.DaysOverdue = task.ElapsedTime - task.AllottedTime;
                task.DaysLate = 0;
            }
            else 
            {
                task.DaysOverdue = 0;
                task.DaysLate = task.AllottedTime - task.ElapsedTime;
            }
            var result = _mapper.Map<TaskBaseDto>(task);
            return new BaseResponse<TaskBaseDto>("Demo returned successfully", result, ResponseCodes.SUCCESS);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while retrieving Demo with {id}.");
            return new BaseResponse<TaskBaseDto>($"An error occurred while retrieving Demo with {id}.", ex.Message);
        }
    }
    public async Task<BaseResponse<TaskBaseDto>> UpdateTask(TaskBaseDto taskDTO)
    {
        try
        {
            var mappedResult = _mapper.Map<TaskProject>(taskDTO);
            TaskProject existingObject = _tasksRepo.SingleOrDefaultAsync(x => x.Id == mappedResult.Id).Result;
            if (existingObject == null)
            {
                return new BaseResponse<TaskBaseDto>($"Object with {mappedResult.Id} Doesn't Exist", ResponseCodes.NOT_FOUND);
            }
             _mapper.Map(taskDTO,existingObject);
            _tasksRepo.Update(existingObject);
            await _unitOfWork.CommitAsync();
            var result = _mapper.Map<TaskBaseDto>(existingObject);
            return new BaseResponse<TaskBaseDto>("Task updated successfully",result ,ResponseCodes.UPDATED);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while Updating Demo with {taskDTO.TaskID}.");
            return new BaseResponse<TaskBaseDto>($"An error occurred while updating Demo with {taskDTO.TaskID}.", ex.Message);
        }
    }
    public async Task<BaseResponse<TaskBaseDto>> DeleteTask(int id)
    {
        try
        {
            var task= await _tasksRepo.GetById(id);
            if (task == null)
            {
                _logger.LogInformation("Task not found. ID: {ID}", id);
                return new BaseResponse<TaskBaseDto>("Task not found", ResponseCodes.NOT_FOUND);
            }
            var existingObject = DeletePrevalidationChecks(task);
            if (existingObject.Item1 == false)
            {
                return new BaseResponse<TaskBaseDto>(existingObject.Item2, ResponseCodes.DUPLICATE_RESOURCE);
            }
             _tasksRepo.Delete(task);
            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Demo deleted successfully. ID: {ID}", id);
            return new BaseResponse<TaskBaseDto>("Demo deleted successfully",  ResponseCodes.DELETED);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while deleting Demo with {id}.");
            return new BaseResponse<TaskBaseDto>($"An error occurred while deleting Demo with {id}.", ex.Message);
        }
    }
    private (bool, string) CreatePrevalidationChecks(TaskProject taskProject)
    {
         var existingTaskProject = _tasksRepo.SingleOrDefaultAsync(x => x.TaskName == taskProject.TaskName).Result;
        if (existingTaskProject != null)
        {
            return (false, "True already exist");
        }
        return (true, string.Empty);
    }
    private (bool, string) DeletePrevalidationChecks(TaskProject taskProject)
    {
        var existingTaskProject = _tasksRepo.SingleOrDefaultAsync(x => x.Id == taskProject.Id).Result;
        if (existingTaskProject == null)
        {
            return (false, $"Object with {taskProject.Id} has been deleted previously");
        }
        return (true, taskProject.Id.ToString());
    }

}


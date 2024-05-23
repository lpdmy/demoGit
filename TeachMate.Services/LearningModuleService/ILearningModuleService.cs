using TeachMate.Domain;

namespace TeachMate.Services;
public interface ILearningModuleService
{
    Task<LearningModule> CreateLearningModule(AppUser user, CreateLearningModuleDto dto);
    Task<LearningModuleRequest> CreateLearningModuleRequest(AppUser user, CreateLearningModuleRequestDto dto);
    Task<LearningModule> EnrollLearningModule(AppUser user, int moduleId);
    Task<List<LearningModule>> GetAllCreatedModules(AppUser user);
    Task<List<LearningModuleRequest>> GetAllCreatedRequests(Guid requesterId);
    Task<List<LearningModule>> GetAllEnrolledModules(AppUser user);
    Task<List<LearningModuleRequest>> GetAllReceivedRequests(Guid tutorId);
    Task<LearningModule?> GetLearningModuleById(int id);
    Task<LearningModuleRequest?> GetRequestById(int id);
    Task<LearningModuleRequest> UpdateRequestStatus(int requestId, UpdateRequestStatusDto dto);
}
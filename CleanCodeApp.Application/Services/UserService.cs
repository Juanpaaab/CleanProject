using CleanCodeApp.Application.DTOs.Response;
using CleanCodeApp.Application.DTOs.Request;
using CleanCodeApp.Domain.Entities;
using CleanCodeApp.Domain.Interfaces;
using Mapster;

namespace CleanCodeApp.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserResDto>> GetAllAsync()
        {
            try
            {
                var users = await _repository.GetAllAsync();
                return users.Adapt<IEnumerable<UserResDto>>();
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserResDto?> GetByIdAsync(int id)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);
                return user.Adapt<UserResDto?>();
            }
            catch
            {
                throw;
            }
        }

        public async Task AddAsync(User user)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                    throw new ArgumentException("El nombre es obligatorio");

                await _repository.AddAsync(user);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                await _repository.UpdateAsync(user);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch
            {
                throw;
            }
        }
    }
}

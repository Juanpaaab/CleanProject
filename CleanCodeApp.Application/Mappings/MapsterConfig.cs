using CleanCodeApp.Domain.Entities;
using CleanCodeApp.Application.DTOs.Request;
using CleanCodeApp.Application.DTOs.Response;
using Mapster;

namespace CleanCodeApp.Application.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings(TypeAdapterConfig config)
        {
            // Dominio → DTO
            config.NewConfig<User, UserResDto>();

            // DTO → Dominio
            config.NewConfig<UserReqDto, User>();
        }
    }
}

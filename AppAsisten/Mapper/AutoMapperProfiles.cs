using AppAsisten.BD.Data.Entity;
using AppAsisten.Shared.DTO;
using AutoMapper;

namespace Concesionaria.Server.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Mapeo de Miembro a MiembroDTO
            CreateMap<Miembro, MiembroDTO>()
                .ForMember(dest => dest.MiembroId, opt => opt.MapFrom(src => src.Id)) // Asumiendo que 'Id' es la propiedad base de EntityBase
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.CodigoQR, opt => opt.MapFrom(src => src.CodigoQR))
                .ForMember(dest => dest.EstaActivo, opt => opt.MapFrom(src => src.EstaActivo));

            // Mapeo de Asistencia a AsistenciaDTO
            CreateMap<Asistencia, AsistenciaRespuestaDTO>()
                .ForMember(dest => dest.MiembroId, opt => opt.MapFrom(src => src.MiembroId))
                .ForMember(dest => dest.Entrada, opt => opt.MapFrom(src => src.Entrada ?? default))
                .ForMember(dest => dest.Salida, opt => opt.MapFrom(src => src.Salida)); // Mapea la fecha de salida, si existe

            // Mapeo inverso (opcional, si deseas mapear de DTO a entidad)
            CreateMap<MiembroDTO, Miembro>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.CodigoQR, opt => opt.MapFrom(src => src.CodigoQR))
                .ForMember(dest => dest.EstaActivo, opt => opt.MapFrom(src => src.EstaActivo));

            CreateMap<AsistenciaRespuestaDTO, Asistencia>()
                .ForMember(dest => dest.MiembroId, opt => opt.MapFrom(src => src.MiembroId))
                .ForMember(dest => dest.Entrada, opt => opt.MapFrom(src => src.Entrada))
                .ForMember(dest => dest.Salida, opt => opt.MapFrom(src => src.Salida));
        }
    }
}

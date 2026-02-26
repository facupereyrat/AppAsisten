using AppAsisten.BD.Data.Entity;
using AppAsisten.Shared.DTO;
using AutoMapper;

namespace AppAsisten.Server.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Mapeo de Miembro a MiembroDTO
            CreateMap<Miembro, MiembroDTO>()
                .ForMember(dest => dest.MiembroId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.CodigoQR, opt => opt.MapFrom(src => src.CodigoQR))
                .ForMember(dest => dest.EstaActivo, opt => opt.MapFrom(src => src.EstaActivo));

            // Mapeo de Asistencia a AsistenciaRespuestaDTO SIN MiembroId
            CreateMap<Asistencia, AsistenciaRespuestaDTO>()
                .ForMember(dest => dest.Entrada, opt => opt.MapFrom(src => src.Entrada ?? default))
                .ForMember(dest => dest.Salida, opt => opt.MapFrom(src => src.Salida));

            // Mapeo inverso MiembroDTO a Miembro
            CreateMap<MiembroDTO, Miembro>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.CodigoQR, opt => opt.MapFrom(src => src.CodigoQR))
                .ForMember(dest => dest.EstaActivo, opt => opt.MapFrom(src => src.EstaActivo));

            // Mapeo inverso AsistenciaRespuestaDTO a Asistencia SIN MiembroId
            CreateMap<AsistenciaRespuestaDTO, Asistencia>()
                .ForMember(dest => dest.Entrada, opt => opt.MapFrom(src => src.Entrada))
                .ForMember(dest => dest.Salida, opt => opt.MapFrom(src => src.Salida));
        }
    }
}

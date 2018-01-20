namespace EvoMp.Module.VehicleHandler.Server.Entity
{
    public class Mapping
    {
        public Mapping()
        {
            //TODO: Remove if new solution works
            /*  #region Vehicle Position & Rotation
              // VehicleMap to VehicleDto
              CreateMap<VehicleMap, VehicleDto>()
                  .ForMember(dest => dest.Position,
                      mapExpession => mapExpession.MapFrom(source => new Vector3(source.X, source.Y, source.Z)))
                  .ForMember(destination => destination.Rotation,
                      mapExpression => mapExpression.MapFrom(source => new Vector3(source.Xr, source.Yr, source.Zr)));
  
              // VehicleDto to VehicleMap
              CreateMap<VehicleDto, VehicleMap>()
                  .ForMember(destination => destination.X,
                      mapExpression => mapExpression.MapFrom(source => source.Position.X))
                  .ForMember(destination => destination.Y,
                      mapExpression => mapExpression.MapFrom(source => source.Position.Y))
                  .ForMember(destination => destination.Z,
                      mapExpression => mapExpression.MapFrom(source => source.Position.Z))
                  .ForMember(destination => destination.Xr,
                      mapExpression => mapExpression.MapFrom(source => source.Rotation.X))
                  .ForMember(destination => destination.Yr,
                      mapExpression => mapExpression.MapFrom(source => source.Rotation.Y))
                  .ForMember(destination => destination.Zr,
                      mapExpression => mapExpression.MapFrom(source => source.Rotation.Z));
              #endregion //Vehicle Position & Rotation
              */
        }
    }
}

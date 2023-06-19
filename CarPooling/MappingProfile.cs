using CarPooling.API.RequestDTOs;
using AutoMapper;
using CarPooling.API.ResponseDTOs;

namespace CarPooling.API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, DomainModels.User>().ReverseMap();
            CreateMap<DomainModels.User, Data.DataModels.User>().ReverseMap();
            CreateMap<OfferRideRequest, Carpooling.DomainModels.OfferRide>().ReverseMap();
            CreateMap<Carpooling.DomainModels.OfferRide, Data.DataModels.OfferRide>().ReverseMap();
            CreateMap<RidesRequest, Carpooling.DomainModels.OfferRide>().ReverseMap();
            CreateMap<BookRideRequest, Carpooling.DomainModels.BookRide>().ReverseMap();
            CreateMap<Carpooling.DomainModels.BookRide, Data.DataModels.BookRide>().ReverseMap();
            CreateMap<Carpooling.DomainModels.OfferRide, OfferRideResponse>().ReverseMap();
        }
    }
}

using Trade.Domain.Dtos;
using Trade.Domain.Interfaces;
using Trade.Domain.Interfaces.MessageBroker;
using AutoMapper;
using Trade.Domain.Entities;
using Trade.Domain.RepositoryContracts;

namespace Trade.Application.AppUsecases.Stocks.CreateStocks
{
    public class CreateStockUsecase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _busControl;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentContext _currentContext;
        public CreateStockUsecase(IUnitOfWork unitOfWork, IBus busControl, IMapper mapper, IUserRepository userRepository, ICurrentContext currentContext) 
        {
            _unitOfWork = unitOfWork;
            _busControl = busControl;
            _mapper = mapper;
            _userRepository = userRepository;
            _currentContext = currentContext;
        }

        public async Task CreateStock(StockRequestDto stock)
        {
            var stockProduct = _mapper.Map<StockRequestDto, StockProduct>(stock);
            var userId = _currentContext.LoggedInUser;
            var user = _userRepository.GetUserById(userId);
            stockProduct.UserId = user.Id;
            _unitOfWork.StockProductRepository.CreateStock(stockProduct);
            _unitOfWork.Complete();
           
        }
    }
}

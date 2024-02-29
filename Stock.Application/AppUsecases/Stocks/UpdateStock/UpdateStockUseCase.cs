using Trade.Domain.Dtos;
using Trade.Domain.Interfaces;


namespace Trade.Application.AppUsecases.Stocks.UpdateStock
{
    public class UpdateStockUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateStockUseCase(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public void UpdateStock (StockRequestDto stock, string id)
        {
            _unitOfWork.StockProductRepository.PutStock (stock, id);
            _unitOfWork.Complete();
        }
    }
}

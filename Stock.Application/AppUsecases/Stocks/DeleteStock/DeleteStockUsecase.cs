﻿using Trade.Domain.Interfaces;

namespace Trade.Application.AppUsecases.Stocks.DeleteStock
{
    public class DeleteStockUsecase
    {

        private readonly IUnitOfWork _unitOfWork;
        public DeleteStockUsecase(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteStock(string id) 
        {
            _unitOfWork.StockProductRepository.DeleteStockById(id);
            _unitOfWork.Complete();
        }
    }
}

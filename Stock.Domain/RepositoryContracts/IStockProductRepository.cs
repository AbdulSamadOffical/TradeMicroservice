using Trade.Domain.DomainEntities;
using Trade.Domain.Dtos;
using Trade.Domain.Entities;


namespace Trade.Domain.RepositoryContracts
{
    public interface IStockProductRepository
    {
        public StockDomain GetStockById(string id);
        public IEnumerable<StockDomain> GetAllStocks();
        public StockDomain GetStockBySymbol(string symbol);
        public void CreateStock(StockProduct stock);
        public void PutStock(StockRequestDto stock, string id);
        public void DeleteStockById(string id);
    }
}

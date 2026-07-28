
using Stock_app.DTOs;
using Stock_app.Models;
using Stock_app.Services.Helpers;

namespace Stock_app.Services
{
    public class StockServices : IStocksService
    {
        private readonly List<BuyOrder> _buyOrders;
        private readonly List<SellOrder> _sellOrders;

        public StockServices() {
            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();
        }


        public BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if (buyOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(buyOrderRequest));
            }

            // model validation
            ValidationHelper.ModelValidation(buyOrderRequest);

            // convert buyer order request into buyer order type.
            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            // generate BuyOrderId 
            buyOrder.BuyOrderId = Guid.NewGuid();

            _buyOrders.Add(buyOrder);

            return buyOrder.ToBuyOrderResponse();

        }

        public SellOrderResponse CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(sellOrderRequest));
            }

            // convert the requestSellObject into sellObject
            SellOrder sellOrder = sellOrderRequest.ToSellOrder();

            // set the guid
            sellOrder.SellOrderId = Guid.NewGuid();

            // add in the list
            _sellOrders.Add(sellOrder);


            return sellOrder.ToSellOrderResponse();
        }

        public List<BuyOrderResponse> GetBuyOrders()
        {
            //Convert all BuyOrder objects into BuyOrderResponse objects
            return _buyOrders
                    .OrderByDescending(temp => temp.DateAndTimeOfOrder)
                    .Select(temp => temp.ToBuyOrderResponse()).ToList();
        }

        public List<SellOrderResponse> GetSellOrders()
        {
            return _sellOrders
                    .OrderByDescending(temp => temp.DateAndTimeOfOrder)
                    .Select(temp => temp.ToSellOrderResponse()).ToList();
        }
    }
}

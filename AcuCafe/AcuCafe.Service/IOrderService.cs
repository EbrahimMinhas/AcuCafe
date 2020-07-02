using AcuCafe.Model;
using AcuCafe.Model.Enums;

namespace AcuCafe.Service
{
    public interface IOrderService
    {
        Receipt ProcessOrder(Order order);
    }
}
